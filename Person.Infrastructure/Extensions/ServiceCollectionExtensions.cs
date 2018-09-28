using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Person.Domain.Repositories;
using Person.Infrastructure.Context;
using Person.Infrastructure.Repositories;

namespace Person.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PersonDbContext>();
            services.AddScoped<IUnitOfWork, EFUnitOfWork>();
            services.AddScoped<IPersonRepository, PersonRepository>();
        }
    }
}