using Person.Common.Interfaces;
using Person.Presentation.Models;

namespace Person.Presentation.Mappers.Interfaces
{
    public interface IUpdatePersonModelToPersonMapper : IMapper<UpdatePersonModel, Domain.Entities.Person>
    {
    }
}
