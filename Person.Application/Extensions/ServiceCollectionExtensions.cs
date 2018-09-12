using Microsoft.Extensions.DependencyInjection;
using Person.Application.Services;
using Person.Domain.Services;

namespace Person.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IPersonApplicationService, PersonApplicationService>();
        }
    }
}
