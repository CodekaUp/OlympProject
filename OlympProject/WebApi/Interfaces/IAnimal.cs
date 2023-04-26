using OlympProject.WebApi.Models;
using OlympProject.WebApi.Models.Request;
using System.Diagnostics.Eventing.Reader;

namespace OlympProject.WebApi.Interfaces
{
    public interface IAnimal
    {
        public Animal Get(long id);
        public bool Create(AnimalRequest animalRequest);
        public bool Update(long id, AnimalRequest animalRequest);
        public bool Delete(long id);
        public List<Animal> Search(DateTime? startDateTime, DateTime? endDateTime, int? chipperId, long? cippingLocationId, string? lifeStatus, string? gender, int from = 0, int size = 10);
        public bool AddAnimalType(long id, long typeid);
        public bool UpdateAnimalType(long id, TypeRequest typeRequest);
        public bool DeleteAnimalType(long id, long typeid);
        public bool AddAnimalLocation(long id, long locationid);
        public bool UpdateAnimalLocation(long id, LocationRequest request);
        public bool DeleteAnimalLocation(long id, long locationid);
    }
}
