using Dapper;
using Person.Common.Interfaces;
using Person.Domain.Repositories;
using Person.Infrastructure.Queries;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Person.Infrastructure.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IDbConnection _connection;
        private readonly ITransactionManager _transactionManager;

        public PersonRepository(IDbConnection connection, ITransactionManager transactionManager)
        {
            _connection = connection;
            _transactionManager = transactionManager;
        }

        public async Task CreatePerson(Domain.Entities.Person person)
        {
            await _connection.QueryAsync(CreatePersonQuery.Query, person, _transactionManager.GetCurrentTransaction());
        }

        public async Task DeletePerson(string key)
        {
            await _connection.QueryAsync(DeletePersonQuery.Query, new { Key = key }, _transactionManager.GetCurrentTransaction());
        }

        public async Task<IEnumerable<Domain.Entities.Person>> GetAllPersons()
        {
            return await _connection.QueryAsync<Domain.Entities.Person>(GetAllPersonsQuery.Query, transaction: _transactionManager.GetCurrentTransaction());
        }

        public async Task<Domain.Entities.Person> GetPersonByKey(string key)
        {
            var result = await _connection.QueryAsync<Domain.Entities.Person>(GetPersonByKeyQuery.Query, new { Key = key }, _transactionManager.GetCurrentTransaction());

            return result.FirstOrDefault();
        }

        public async Task UpdatePerson(Domain.Entities.Person person, string key)
        {
            await _connection.QueryAsync(UpdatePersonQuery.Query, new { Name = person.Name, Age = person.Age, Key = key }, _transactionManager.GetCurrentTransaction());
        }
    }
}