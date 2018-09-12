using Person.Application.Exceptions;
using Person.Domain.Repositories;
using Person.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Person.Application.Services
{
    public class PersonApplicationService : IPersonApplicationService
    {
        private readonly IPersonRepository _repository;

        public PersonApplicationService(IPersonRepository repository)
        {
            _repository = repository;
        }

        public async Task CreatePerson(Domain.Entities.Person person)
        {
            ValidatePerson(person);

            await _repository.CreatePerson(person);
        }

        public async Task DeletePerson(string key)
        {
            if (key != null)
                await _repository.DeletePerson(key);
        }

        public async Task<IEnumerable<Domain.Entities.Person>> GetAllPersons()
        {
            return await _repository.GetAllPersons();
        }

        public async Task<Domain.Entities.Person> GetPersonByKey(string key)
        {
            if (key == null)
                return null;

            return await _repository.GetPersonByKey(key);
        }

        public async Task UpdatePerson(Domain.Entities.Person person, string key)
        {
            if (key == null)
                return;

            ValidatePerson(person);

            await _repository.UpdatePerson(person, key);
        }

        private static void ValidatePerson(Domain.Entities.Person person)
        {
            if (person.Age == 0)
                throw new EntityException(nameof(Domain.Entities.Person.Age), "Idade nao pode ser zero.");

            if (person.Name == null)
                throw new EntityException(nameof(Domain.Entities.Person.Name), "Nome nao pode ser nulo.");

            if (person.Name.Length < 2)
                throw new EntityException(nameof(Domain.Entities.Person.Name), "Tamanho minimo do nome nao pode ser menor que dois.");

            if (person.Name.Length > 50)
                throw new EntityException(nameof(Domain.Entities.Person.Name), "Tamanho maximo do nome nao pode ser maior que cinquenta.");
        }
    }
}
