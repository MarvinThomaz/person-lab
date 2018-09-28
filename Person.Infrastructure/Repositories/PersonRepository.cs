using Microsoft.EntityFrameworkCore;
using Person.Domain.Repositories;
using Person.Infrastructure.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Person.Infrastructure.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly DbContext _context;

        public PersonRepository(PersonDbContext context)
        {
            _context = context;
        }

        public async Task CreatePersonAsync(Domain.Entities.Person person)
        {
            await _context.AddAsync(person);
        }

        public async Task DeletePersonAsync(string key)
        {
            var person = await _context.Set<Domain.Entities.Person>().FirstOrDefaultAsync(p => p.Key == key);

            if (person != null)
                _context.Remove(person);
        }

        public async Task<IEnumerable<Domain.Entities.Person>> GetAllPersonsAsync()
        {
            return await _context.Set<Domain.Entities.Person>().ToListAsync();
        }

        public async Task<Domain.Entities.Person> GetPersonByKeyAsync(string key)
        {
            return await _context.Set<Domain.Entities.Person>().FirstOrDefaultAsync(p => p.Key == key);
        }

        public async Task UpdatePersonAsync(Domain.Entities.Person person, string key)
        {
            person.Key = key;

            await Task.Run(() => _context.Entry(person).State = EntityState.Modified);
        }
    }
}