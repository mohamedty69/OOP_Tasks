using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace API_CRUD.Filter
{
    public class LogSensitiveActionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            //Debug make me write to the output window in Visual Studio when choose Debug mode
            Debug.WriteLine("Sensitive action executed at: " + DateTime.Now);
        }
    }
}
