using FizzWare.NBuilder;
using MySql.Data.MySqlClient;
using Person.Common.Builders;
using Person.Common.Interfaces;
using Person.Domain.Repositories;
using Person.Infrastructure.Repositories;
using Person.Infrastructure.Transaction;
using Person.IntegrationTests.Configuration;
using Person.IntegrationTests.Seed;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Person.IntegrationTests.Infrastructure
{
    public class PersonRepositoryTests
    {
        private readonly Startup startup = new Startup();
        private readonly IPersonRepository _repository;
        private readonly ITransactionManager _transactionManager;
        private readonly IDbConnection _connection;

        public PersonRepositoryTests()
        {
            _connection = new MySqlConnection(startup.ConnectionString);
            _transactionManager = new TransactionManager(_connection);
            _repository = new PersonRepository(_connection, _transactionManager);
        }

        [Fact]
        public async Task CreatePersonAsyncTest()
        {
            var person = Builder<Domain.Entities.Person>
                .CreateNew()
                .With(p => p.Key = KeyBuilder.Build())
                .Build();

            await _repository.CreatePersonAsync(person);

            var persistedPerson = await _repository.GetPersonByKeyAsync(person.Key);

            Assert.Equal(person.Key, persistedPerson.Key);
            Assert.Equal(person.Name, persistedPerson.Name);
            Assert.Equal(person.Age, persistedPerson.Age);
        }

        [Fact]
        public async Task UpdatePersonAsyncTest()
        {
            PersonRepositorySeed.ExecuteSeed(_connection);

            var persistedPerson = PersonRepositorySeed.Persons.First();

            var person = await _repository.GetPersonByKeyAsync(persistedPerson.Key);

            Assert.Equal(person.Key, persistedPerson.Key);
            Assert.Equal(person.Name, persistedPerson.Name);
            Assert.Equal(person.Age, persistedPerson.Age);

            PersonRepositorySeed.FinishSeed(_connection);
        }
    }
}