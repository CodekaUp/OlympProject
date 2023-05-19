using OlympProject.WebApi.Models;
using OlympProject.WebApi.Models.Request;
using OlympProject.WebApi.Models.Response;

namespace OlympProject.WebApi.Interfaces
{
    public interface IAnimalType
    {
        public AnimalType Get(long id);
        public AnimalTypeResponse Create(AnimalTypeRequest animalTypeRequest);
        public AnimalTypeResponse Update(long id, AnimalTypeRequest animalTypeRequest);
        public bool Delete(long id);
    }
}
