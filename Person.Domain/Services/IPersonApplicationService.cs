using System.Collections.Generic;
using System.Threading.Tasks;

namespace Person.Domain.Services
{
    public interface IPersonApplicationService
    {
        Task CreatePersonAsync(Entities.Person person);
        Task UpdatePersonAsync(Entities.Person person, string key);
        Task DeletePersonAsync(string key);
        Task<Entities.Person> GetPersonByKeyAsync(string key);
        Task<IEnumerable<Entities.Person>> GetAllPersonsAsync();
    }
}