using Person.Common.Builders;
using Person.Presentation.Mappers.Interfaces;
using Person.Presentation.Models;

namespace Person.Presentation.Mappers.Implementations
{
    public class CreatePersonModelToPersonMapper : ICreatePersonModelToPersonMapper
    {
        public Domain.Entities.Person Map(CreatePersonModel source)
        {
            return new Domain.Entities.Person
            {
                Age = source.Age,
                Key = KeyBuilder.Build(),
                Name = source.Name
            };
        }
    }
}