using finance.src.shared.infratruction.exceptions.http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace finance.api.src.shared.infratruction.middleware.http
{
    public class ConflictExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is ConflictException)
            {
                context.Result = new ObjectResult(new
                {
                    statusCode = HttpStatusCode.Conflict,
                    error = context.Exception.Message,
                    date = DateTime.Now
                })
                {
                    StatusCode = (int)HttpStatusCode.Conflict
                };
                context.ExceptionHandled = true;
            }
            else
            {
                return;
            }
        }
    }
}
