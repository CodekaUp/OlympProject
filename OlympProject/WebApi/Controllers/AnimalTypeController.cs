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
        public ActionResult<AnimalType> Get(long id)
        {
            var animaltype = this.animalType.Get(id);
            
            return Ok(animaltype);
        }

        [HttpPost, Route("animals/types")]
        public void Create(AnimalTypeRequest animalTypeRequest)
        {
            animalType.Create(animalTypeRequest);
        }

        [HttpPut, Route("animals/types/{id}")]
        public void Update(long id, AnimalTypeRequest animalTypeRequest)
        {
            animalType.Update(id, animalTypeRequest);
        }

        [HttpDelete, Route("animals/types/{id}")]
        public void Delete(long id)
        {
            animalType.Delete(id);
        }

    }
}
