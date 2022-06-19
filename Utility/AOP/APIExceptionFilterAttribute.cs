using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Utility.AOP
{
    public class APIExceptionFilterAttribute : Attribute, IExceptionFilter
    {
        private readonly ILogger<APIExceptionFilterAttribute> _logger;

        public APIExceptionFilterAttribute(ILogger<APIExceptionFilterAttribute> logger)
        {
            this._logger = logger;
        }
        public void OnException(ExceptionContext context)
        {
            
            if (context.ExceptionHandled == false)
            {
               _logger.LogError(context.Exception.Message);
                context.Result = new  JsonResult(new
                {
                    Success = false,
                    Message = context.Exception.Message
                }); 
                context.ExceptionHandled = true;
            }
         }
    }
}
