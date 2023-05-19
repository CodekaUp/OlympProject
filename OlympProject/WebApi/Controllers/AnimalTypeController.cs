using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OlympProject.WebApi.Interfaces;
using OlympProject.WebApi.Models;
using OlympProject.WebApi.Models.Request;

namespace OlympProject.WebApi.Controllers
{
    [Route("")]
    [ApiController]
    public class AnimalTypeController : ControllerBase
    {
        private readonly IAnimalType animalType;
        public AnimalTypeController(IAnimalType animalType)
        {
            this.animalType = animalType;
        }

        [HttpGet, Route("animals/types/{id}")]
        public IActionResult Get(long id)
        {
            var animaltype = this.animalType.Get(id);
            return Ok(animaltype);
        }

        [HttpPost, Route("animals/types")]
        public IActionResult Create(AnimalTypeRequest animalTypeRequest)
        {
            var response = animalType.Create(animalTypeRequest);
            return Ok(response);

        }

        [HttpPut, Route("animals/types/{id}")]
        public IActionResult Update(long id, AnimalTypeRequest animalTypeRequest)
        {
            var response = animalType.Update(id, animalTypeRequest);
            return Ok(response);
        }

        [HttpDelete, Route("animals/types/{id}")]
        public IActionResult Delete(long id)
        {
            animalType.Delete(id);
            return Ok();
        }

    }
}
