using OlympProject.WebApi.Models;
using OlympProject.WebApi.Models.Request;
using OlympProject.WebApi.Models.Response;
using System.Diagnostics.Eventing.Reader;

namespace OlympProject.WebApi.Interfaces
{
    public interface IAnimal
    {
        public Animal Get(long id);
        public AnimalResponse Create(AnimalRequest animalRequest);
        public AnimalResponse Update(long id, AnimalRequest animalRequest);
        public bool Delete(long id);
        public List<Animal> Search(DateTime? startDateTime, DateTime? endDateTime, int? chipperId, long? cippingLocationId, string? lifeStatus, string? gender, int from = 0, int size = 10);
        public AnimalResponse AddAnimalType(long id, long typeid);
        public AnimalResponse UpdateAnimalType(long id, TypeRequest typeRequest);
        public AnimalResponse DeleteAnimalType(long id, long typeid);
        public bool AddAnimalLocation(long id, long locationid);
        public bool UpdateAnimalLocation(long id, LocationRequest request);
        public bool DeleteAnimalLocation(long id, long locationid);
    }
}
