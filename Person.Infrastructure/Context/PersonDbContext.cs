using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Person.Infrastructure.Context
{
    public class PersonDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public PersonDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = _configuration.GetConnectionString("DefaultConnection");

                optionsBuilder.UseMySql(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Entities.Person>();
        }
    }
}