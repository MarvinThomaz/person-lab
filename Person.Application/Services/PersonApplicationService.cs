using Person.Application.Exceptions;
using Person.Domain.Repositories;
using Person.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Person.Application.Services
{
    public class PersonApplicationService : IPersonApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PersonApplicationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreatePersonAsync(Domain.Entities.Person person)
        {
            ValidatePerson(person);

            await _unitOfWork.PersonRepository.CreatePersonAsync(person);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeletePersonAsync(string key)
        {
            if (key != null)
                await _unitOfWork.PersonRepository.DeletePersonAsync(key);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<Domain.Entities.Person>> GetAllPersonsAsync()
        {
            return await _unitOfWork.PersonRepository.GetAllPersonsAsync();
        }

        public async Task<Domain.Entities.Person> GetPersonByKeyAsync(string key)
        {
            if (key == null)
                return null;

            return await _unitOfWork.PersonRepository.GetPersonByKeyAsync(key);
        }

        public async Task UpdatePersonAsync(Domain.Entities.Person person, string key)
        {
            if (key == null)
                return;

            ValidatePerson(person);

            await _unitOfWork.PersonRepository.UpdatePersonAsync(person, key);
            await _unitOfWork.SaveChangesAsync();
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
