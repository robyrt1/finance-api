using finance.api.src.shared.infratruction.exceptions.http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace finance.api.src.shared.infratruction.middleware.http
{
    public class UnauthorizedExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {

            if (context.Exception is UnauthorizedException)
            {
                context.Result = new ObjectResult(new { statusCode = HttpStatusCode.Unauthorized, error = context.Exception.Message, date = DateTime.Now, data = context.HttpContext.Response.Body.ToString() })
                {
                    StatusCode = (int)HttpStatusCode.Unauthorized
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
