using OlympProject.WebApi.Models;
using OlympProject.WebApi.Models.Request;

namespace OlympProject.WebApi.Interfaces
{
    public interface ILocationPoint
    {
        public LocationPoint Get(long id);
        public bool Create(LocationPointRequest locationPointRequest);
        public bool Update(long id, LocationPointRequest locationPointRequest);
        public bool Delete(long id);
    }
}
