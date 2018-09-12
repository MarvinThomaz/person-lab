using Person.Common.Interfaces;
using Person.Domain.Repositories;
using Person.Presentation.Models;

namespace Person.Presentation.Mappers.Interfaces
{
    public interface ICreatePersonModelToPersonMapper : IMapper<CreatePersonModel, Domain.Entities.Person>
    {
    }
}