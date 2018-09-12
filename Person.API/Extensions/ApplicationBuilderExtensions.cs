using Microsoft.AspNetCore.Builder;
using Person.API.Middlewares;

namespace Person.API.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void UseException(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}