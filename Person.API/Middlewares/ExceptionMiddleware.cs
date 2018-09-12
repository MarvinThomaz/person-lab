using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Person.Application.Exceptions;
using System.Threading.Tasks;

namespace Person.API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (EntityException ex)
            {
                var response = new { Message = ex.Message, Property = ex.Property, Result = false };

                await CreateResponse(context, response, StatusCodes.Status422UnprocessableEntity);
            }
            catch (System.Exception ex)
            {
                var response = new { Message = ex.Message, Result = false };
                
                await CreateResponse(context, response, StatusCodes.Status500InternalServerError);
            }
        }

        private async Task CreateResponse(HttpContext context, object response, int statusCode)
        {
            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";

            await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }
    }
}
