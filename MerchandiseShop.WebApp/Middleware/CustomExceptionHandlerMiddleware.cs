using FluentValidation;
using MerchandiseShop.Application.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;

namespace MerchandiseShop.WebApp.Middleware
{
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }   

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }catch(Exception e)
            {
                await HandleExceptionAsync(context, e);
            }
        }

        public Task HandleExceptionAsync(HttpContext context, Exception e)
        {
            var code = HttpStatusCode.InternalServerError;
            var result = string.Empty;
            switch (e)
            {
                case ValidationException validationException:
                    code = HttpStatusCode.BadRequest;
                    result = JsonSerializer.Serialize(validationException.Errors);
                    break;
                case NotFoundException:
                    code = HttpStatusCode.NotFound;
                    break;
            }
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            if(result == string.Empty)
            {
                result = JsonSerializer.Serialize(new { errpr = e.Message });
            }

            return context.Response.WriteAsync(result);
        }
    }
}
