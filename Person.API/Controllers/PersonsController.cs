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
        public async Task<IActionResult> PostAsync([FromBody] CreatePersonModel model, [FromServices] ICreatePersonModelToPersonMapper mapper)
        {
            var entity = mapper.Map(model);

            await _service.CreatePersonAsync(entity);

            return Created($"/api/persons/{entity.Key}", model);
        }

        [HttpPut]
        [Route("{key}")]
        [SwaggerRequestExample(typeof(UpdatePersonModel), typeof(UpdatePersonModelExample))]
        public async Task<IActionResult> PutAsync(string key, [FromBody] UpdatePersonModel model, [FromServices] IUpdatePersonModelToPersonMapper mapper)
        {
            var entity = mapper.Map(model);

            await _service.UpdatePersonAsync(entity, key);

            return Ok();
        }

        [HttpDelete]
        [Route("{key}")]
        public async Task<IActionResult> DeleteAsync(string key)
        {
            await _service.DeletePersonAsync(key);

            return NoContent();
        }

        [HttpGet]
        [Route("{key}")]
        public async Task<IActionResult> GetAsync(string key)
        {
            var entity = await _service.GetPersonByKeyAsync(key);

            if (entity != null)
                return Ok(entity);

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var list = await _service.GetAllPersonsAsync();

            return Ok(list);
        }
    }
}