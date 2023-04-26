using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OlympProject.WebApi.Interfaces;
using OlympProject.WebApi.Models;
using OlympProject.WebApi.Models.Request;
using System.Diagnostics.Eventing.Reader;

namespace OlympProject.WebApi.Controllers
{
    [Route("")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimal animal;
        public AnimalController(IAnimal animal)
        {
            this.animal = animal;
        }

        [HttpGet, Route("animals/{id}")]
        public ActionResult<Animal> Get(long id)
        {
            var responses = animal.Get(id);
            
            return Ok(responses);
        }

        [HttpGet, Route("animals/search")]
        public ActionResult<List<Animal>> Search(DateTime? startDateTime, DateTime? endDateTime, int? chipperId, long? chippingLocationId, string? lifeStatus, string? gender, int from = 0, int size = 10)
        {
            var responses = animal.Search(startDateTime, endDateTime, chipperId, chippingLocationId, lifeStatus, gender, from, size);

            return Ok(responses);
        }

        [HttpPost, Route("animals")]
        public void Create(AnimalRequest animalRequest)
        {
            animal.Create(animalRequest);
        }

        [HttpPut, Route("animals/{id}")]
        public void Update(long id, AnimalRequest animalRequest)
        {
            animal.Update(id, animalRequest);
        }

        [HttpDelete, Route("animals/{id} ")]
        public void Delete(long id)
        {
            animal.Delete(id);
        }

        [HttpPost, Route("animals/{id}/types/{typeid}")]
        public void AddAnimalType(long id, long typeid)
        {
            animal.AddAnimalType(id, typeid);
        }

        [HttpPut, Route("animals/{id}/types")]
        public void UpdateAnimalType(long id, TypeRequest typeRequest)
        {
            animal.UpdateAnimalType(id, typeRequest);
        }

        [HttpDelete, Route("animals/{id}/types/{typeid}")]
        public void DeleteAnimalType(long id, long typeid)
        {
            animal.DeleteAnimalType(id, typeid);
        }

        [HttpPost, Route("animals/{id}/locations/{locationid}")]
        public void AddAnimalLocation(long id, long locationid)
        {
            animal.AddAnimalLocation(id, locationid);
        }

        [HttpPut, Route("animals/{id}/locations")]
        public void UpdateAnimalLocation(long id, LocationRequest request)
        {
            animal.UpdateAnimalLocation(id, request);
        }

        [HttpDelete, Route("animals/{id}/locayions/{locationid}")]
        public void DeleteAnimalLocation(long id, long locationid)
        {
            animal.DeleteAnimalLocation(id, locationid);
        }
    }
}
