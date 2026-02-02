using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.Json;

namespace API_CRUD.Filter
{
    //filter class need to inherit from IActionFilter or IAsyncActionFilter
    //if you implement both interfaces the async method will be called it will ignore the sync method
    public class LogActivityFilter : IActionFilter,IAsyncActionFilter
    {
        private ILogger<LogActivityFilter> _logger;

        public LogActivityFilter(ILogger<LogActivityFilter> logger)
        {
            _logger = logger;
        }
        //when we start action method this method will be called
        //what is the diff between using HttpContext in middleware and using ActionExecutingContext in filter
        //HttpContext is used in middleware to access request and response information from url,headers,body etc
        //ActionExecutingContext is used in filter to access action method information like action name,controller name,action parameters etc
        //ActionExecutingContext is more specific to the request being processed by the action method
        public void OnActionExecuting(ActionExecutingContext context)
        {
            //the arguments sent to the action method as a json object so we need to convert it to string with Jsonserializer
            _logger.LogInformation($"Action Method {context.ActionDescriptor.DisplayName} of Controller {context.Controller} with arguments{JsonSerializer.Serialize(context.ActionArguments)}");
            //if you update the result property of the context object you can short-circuit the action method execution (skip the action method execution)
            //sort-circuiting(means that don`t excute the action method that is in the controller) is useful for validation or authentication
            context.Result = new NotFoundResult();
        }
        //when action method is completed this method will be called
        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation($"Action Method {context.ActionDescriptor.DisplayName} executed successfully on controller {context.Controller}.");
        }
        //notice that this method is have parameter of type ActionExecutionDelegate next and ActionExecutingContext context like the Invoke method in middleware
        //so you need to call await next() to proceed to the action method execution if you don`t call it the action method will be skipped
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            _logger.LogInformation($"(Async) Action Method {context.ActionDescriptor.DisplayName} of Controller {context.Controller} with arguments{JsonSerializer.Serialize(context.ActionArguments)}");
            await next();
            _logger.LogInformation($"(Async) Action Method {context.ActionDescriptor.DisplayName} executed successfully on controller {context.Controller}.");
        }
    }
}
