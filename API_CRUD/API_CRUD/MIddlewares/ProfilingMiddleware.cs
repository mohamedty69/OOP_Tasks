using System.Diagnostics;

namespace API_CRUD.MIddlewares
{
    //middleware class for profiling -middleware does not have any attribute or inherit any class
    //must do a registration in Program.cs file
    public class ProfilingMiddleware
    {
        private RequestDelegate _next;
        private ILogger<ProfilingMiddleware> _logger;

        //first pass parameter in the constructor is RequestDelegate type
        public ProfilingMiddleware(RequestDelegate next,ILogger<ProfilingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        //HttpContext parameter in Invoke method 
        //this Type or class is from Microsoft.AspNetCore.Http namespace that represent the HTTP request and response
        //it contains all the information about the HTTP request
        public async Task Invoke(HttpContext context)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            await _next(context);
            stopwatch.Stop();
            _logger.LogInformation($"Request {context.Request.Path} took {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}
