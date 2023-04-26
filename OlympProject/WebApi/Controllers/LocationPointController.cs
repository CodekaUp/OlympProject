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
        public ActionResult<LocationPoint> Get(long id)
        {
            var locationPoint = this.locationPoint.Get(id);
            
            return Ok(locationPoint);
        }

        [HttpPost, Route("locations")]
        public void Create(LocationPointRequest locationPointRequest)
        {
            locationPoint.Create(locationPointRequest);
        }

        [HttpPut, Route("locations/{id}")]
        public void Update(long id, LocationPointRequest locationPointRequest)
        {
            locationPoint.Update(id, locationPointRequest);
        }

        [HttpDelete, Route("locations/{id}")]
        public void Delete(long id)
        {
            locationPoint.Delete(id);
        }

    }
}
