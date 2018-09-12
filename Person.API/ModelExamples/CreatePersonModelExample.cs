using Person.Presentation.Models;
using Swashbuckle.AspNetCore.Examples;

namespace Person.API.ModelExamples
{
    public class CreatePersonModelExample : IExamplesProvider
    {
        public object GetExamples()
        {
            return new CreatePersonModel
            {
                Age = 27,
                Name = "Marvin Thomaz do Nascimento"
            };
        }
    }
}