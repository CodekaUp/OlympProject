using OlympProject.WebApi.Models;
using OlympProject.WebApi.Models.Request;
using OlympProject.WebApi.Models.Response;

namespace OlympProject.WebApi.Interfaces
{
    public interface ILocationPoint
    {
        public LocationPoint Get(long id);
        public LocationPointResponse Create(LocationPointRequest locationPointRequest);
        public LocationPointResponse Update(long id, LocationPointRequest locationPointRequest);
        public bool Delete(long id);
    }
}
