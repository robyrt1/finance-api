namespace finance.api.src.shared.infratruction.middleware.http
{
    using finance.api.src.shared.infratruction.exceptions.http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using System.Net;


    public class NotFoundExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {

            if (context.Exception is NotFoundException)
            {
                context.Result = new ObjectResult(new { statusCode = HttpStatusCode.NotFound, error = context.Exception.Message, date = DateTime.Now, data = context.HttpContext.Response.Body.ToString() })
                {
                    StatusCode = (int)HttpStatusCode.NotFound
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
