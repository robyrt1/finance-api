using finance.src.shared.infratruction.exceptions.http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace finance.api.src.shared.infratruction.middleware
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            ;
           
            if (context.Exception is NotFoundException)
            {
                context.Result = new ObjectResult(new { statusCode = context.HttpContext.Response.StatusCode.ToString(), error = context.Exception.Message, date = DateTime.Now, data = context.HttpContext.Response.Body.ToString() })
                {
                    StatusCode = (int)HttpStatusCode.NotFound
                };
                context.ExceptionHandled = true;
            }
            else
            {
                // Trate outras exceções ou deixe que sejam tratadas pelo middleware padrão
                context.Result = new ObjectResult(new { statusCode = HttpStatusCode.InternalServerError, error = context.Exception.Message, date = DateTime.Now, data = context.HttpContext.Response.Body.ToString() })
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
                context.ExceptionHandled = true;
            }
        }
    }
}
