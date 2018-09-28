using Person.Domain.Repositories;
using Person.Infrastructure.Repositories;

namespace Person.UnitTests.Infrastructure
{
    public class PersonRepositoryTests
    {
        private readonly IPersonRepository _personRepository = new PersonRepository();

        public PersonRepositoryTests()
        {

        }
    }
}
