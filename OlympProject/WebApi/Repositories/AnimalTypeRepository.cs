using AutoMapper;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Identity.Client;
using OlympProject.Database;
using OlympProject.WebApi.Interfaces;
using OlympProject.WebApi.Models;
using OlympProject.WebApi.Models.Request;
using OlympProject.WebApi.Models.Response;

namespace OlympProject.WebApi.Repositories
{
    public class AnimalTypeRepository : IAnimalType
    {
        private readonly AppDBContext context;
        private readonly IMapper mapper;

        public AnimalTypeRepository(AppDBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public AnimalTypeResponse Create(AnimalTypeRequest animalTypeRequest)
        {
            try
            {
                var animaltype = new AnimalType()
                {
                    Type = animalTypeRequest.Type,
                };
                context.AnimalTypes.Add(animaltype);
                context.SaveChanges();
                var response = mapper.Map<AnimalTypeResponse>(animaltype);
                return response;
            }
            catch(Exception ex)
            {
                throw new InvalidDataException(ex.Message, ex);
            }
        }

        public bool Delete(long id)
        {
            try
            {
                var animaltype = Get(id);
                if (animaltype != null)
                {
                    context.AnimalTypes.Remove(animaltype);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    throw new InvalidDataException("Не найдено");
                }
            }
            catch(Exception ex)
            {
                throw new InvalidDataException(ex.Message, ex);
            }
        }

        public AnimalType Get(long id)
        {
            try
            {
                var animaltype = context.AnimalTypes.SingleOrDefault(x => x.Id == id);
                if (animaltype != null)
                {
                    return animaltype;
                }
                else
                {
                    throw new InvalidDataException("Не найдено");
                }
            }
            catch(Exception ex)
            {
                throw new InvalidDataException(ex.Message, ex);
            }
        }

        public AnimalTypeResponse Update(long id, AnimalTypeRequest animalTypeRequest)
        {
            try
            {
                var animaltype = Get(id);
                if (animaltype != null)
                {
                    animaltype.Type = animalTypeRequest.Type;
                    context.SaveChanges();
                    var response = mapper.Map<AnimalTypeResponse>(animaltype);
                    return response;
                }
                else
                {
                    throw new InvalidDataException("Не найдено");
                }
            }
            catch(Exception ex)
            {
                throw new InvalidDataException(ex.Message, ex);
            }
        }
    }
}
