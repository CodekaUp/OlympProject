using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OlympProject.WebApi.Interfaces;
using OlympProject.WebApi.Models;
using OlympProject.WebApi.Models.Request;

namespace OlympProject.WebApi.Controllers
{
    [Route("")]
    [ApiController]
    public class LocationPointController : ControllerBase
    {
        private readonly ILocationPoint locationPoint;

        public LocationPointController(ILocationPoint locationPoint)
        {
            this.locationPoint = locationPoint;
        }

        [HttpGet, Route("locations/{id}")]
        public IActionResult Get(long id)
        {
            var locationPoint = this.locationPoint.Get(id);
            
            return Ok(locationPoint);
        }

        [HttpPost, Route("locations")]
        public IActionResult Create(LocationPointRequest locationPointRequest)
        {
            var response = locationPoint.Create(locationPointRequest);
            return Ok(response);
        }    

        [HttpPut, Route("locations/{id}")]
        public IActionResult Update(long id, LocationPointRequest locationPointRequest)
        {
            var response = locationPoint.Update(id, locationPointRequest);
            return Ok(response);
        }

        [HttpDelete, Route("locations/{id}")]
        public IActionResult Delete(long id)
        {
            locationPoint.Delete(id);
            return Ok();
        }

    }
}
