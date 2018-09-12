using Dapper;
using FizzWare.NBuilder;
using MySql.Data.MySqlClient;
using NSubstitute;
using Person.Common.Interfaces;
using Person.Domain.Repositories;
using Person.Infrastructure.Queries;
using Person.Infrastructure.Repositories;
using Person.Infrastructure.Transaction;
using Person.IntegrationTests.Configuration;
using Person.IntegrationTests.Seed;
using System;
using System.Configuration;
using System.Data;
using System.Threading.Tasks;
using Xunit;

namespace Person.IntegrationTests.Infrastructure
{
    public class PersonRepositoryTests : IDisposable
    {
        private readonly Startup startup = new Startup();
        private readonly IPersonRepository _repository;
        private readonly ITransactionManager _transactionManager;
        private readonly IDbConnection _dbConnection;

        public PersonRepositoryTests()
        {
            _dbConnection = new MySqlConnection(startup.ConnectionString);
            _transactionManager = new TransactionManager(_dbConnection);
            _repository = new PersonRepository(_dbConnection, _transactionManager);

            _transactionManager.Begin();

            PersonRepositorySeed.ExecuteSeed(_dbConnection, _transactionManager.GetCurrentTransaction());
        }

        [Fact]
        public async Task CreatePersonAsyncTest()
        {
            var person = Builder<Domain.Entities.Person>.CreateNew().Build();

            await _repository.CreatePersonAsync(person);
        }

        public void Dispose()
        {
            _transactionManager.Rollback();
            _transactionManager.Dispose();
        }
    }
}