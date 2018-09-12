using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;
using Person.Common.Interfaces;
using Person.Domain.Repositories;
using Person.Infrastructure.Repositories;
using Person.Infrastructure.Transaction;
using System.Data;

namespace Person.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IDbConnection>(svcProvider =>
            {
                var connectionString = configuration.GetConnectionString("DefaultConnection");

                return new MySqlConnection(connectionString);
            });

            services.AddScoped<ITransactionManager, TransactionManager>();
            services.AddScoped<IPersonRepository, PersonRepository>();
        }
    }
}