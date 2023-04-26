using OlympProject.WebApi.Models;
using OlympProject.WebApi.Models.Request;

namespace OlympProject.WebApi.Interfaces
{
    public interface IAnimalType
    {
        public AnimalType Get(long id);
        public bool Create(AnimalTypeRequest animalTypeRequest);
        public bool Update(long id, AnimalTypeRequest animalTypeRequest);
        public bool Delete(long id);
    }
}
