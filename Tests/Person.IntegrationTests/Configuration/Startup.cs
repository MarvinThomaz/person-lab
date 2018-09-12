using Microsoft.Extensions.Configuration;

namespace Person.IntegrationTests.Configuration
{
    public class Startup
    {
        public Startup()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            ConnectionString = config["ConnectionStrings:DefaultConnection"];
        }

        public string ConnectionString { get; }
    }
}