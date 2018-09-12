using Microsoft.AspNetCore.Mvc;
using Person.API.ModelExamples;
using Person.Domain.Services;
using Person.Presentation.Mappers.Interfaces;
using Person.Presentation.Models;
using Swashbuckle.AspNetCore.Examples;
using System.Threading.Tasks;

namespace Person.API.Controllers
{
    [Route("api/persons")]
    public class PersonsController : Controller
    {
        private readonly IPersonApplicationService _service;

        public PersonsController(IPersonApplicationService service)
        {
            _service = service;
        }

        [HttpPost]
        [SwaggerRequestExample(typeof(CreatePersonModel), typeof(CreatePersonModelExample))]
        public async Task<IActionResult> Post([FromBody] CreatePersonModel model, [FromServices] ICreatePersonModelToPersonMapper mapper)
        {
            var entity = mapper.Map(model);

            await _service.CreatePerson(entity);

            return Created($"/api/persons/{entity.Key}", model);
        }

        [HttpPut]
        [Route("{key}")]
        [SwaggerRequestExample(typeof(UpdatePersonModel), typeof(UpdatePersonModelExample))]
        public async Task<IActionResult> Put(string key, [FromBody] UpdatePersonModel model, [FromServices] IUpdatePersonModelToPersonMapper mapper)
        {
            var entity = mapper.Map(model);

            await _service.UpdatePerson(entity, key);

            return Ok();
        }

        [HttpDelete]
        [Route("{key}")]
        public async Task<IActionResult> Delete(string key)
        {
            await _service.DeletePerson(key);

            return NoContent();
        }

        [HttpGet]
        [Route("{key}")]
        public async Task<IActionResult> Get(string key)
        {
            var entity = await _service.GetPersonByKey(key);

            if (entity != null)
                return Ok(entity);

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var list = await _service.GetAllPersons();

            return Ok(list);
        }
    }
}