using Person.Presentation.Models;
using Swashbuckle.AspNetCore.Examples;

namespace Person.API.ModelExamples
{
    public class UpdatePersonModelExample : IExamplesProvider
    {
        public object GetExamples()
        {
            return new UpdatePersonModel
            {
                Age = 27,
                Name = "Marvin Thomaz do Nascimento"
            };
        }
    }
}