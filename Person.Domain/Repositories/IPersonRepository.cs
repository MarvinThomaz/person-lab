using System.Collections.Generic;
using System.Threading.Tasks;

namespace Person.Domain.Repositories
{
    public interface IPersonRepository
    {
        Task CreatePerson(Entities.Person person);
        Task UpdatePerson(Entities.Person person, string key);
        Task DeletePerson(string key);
        Task<Entities.Person> GetPersonByKey(string key);
        Task<IEnumerable<Entities.Person>> GetAllPersons();
    }
}