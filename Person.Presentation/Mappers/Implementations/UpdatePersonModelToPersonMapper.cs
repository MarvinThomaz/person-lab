using Person.Presentation.Mappers.Interfaces;
using Person.Presentation.Models;

namespace Person.Presentation.Mappers.Implementations
{
    public class UpdatePersonModelToPersonMapper : IUpdatePersonModelToPersonMapper
    {
        public Domain.Entities.Person Map(UpdatePersonModel source)
        {
            return new Domain.Entities.Person
            {
                Age = source.Age,
                Name = source.Name
            };
        }
    }
}
