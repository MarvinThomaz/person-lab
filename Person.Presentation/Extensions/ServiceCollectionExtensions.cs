using Microsoft.Extensions.DependencyInjection;
using Person.Presentation.Mappers.Implementations;
using Person.Presentation.Mappers.Interfaces;

namespace Person.Presentation.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddPresentation(this IServiceCollection services)
        {
            services.AddSingleton<ICreatePersonModelToPersonMapper, CreatePersonModelToPersonMapper>();
            services.AddSingleton<IUpdatePersonModelToPersonMapper, UpdatePersonModelToPersonMapper>();
        }
    }
}