using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using OlympProject.Database;
using OlympProject.WebApi.Interfaces;
using OlympProject.WebApi.Models;
using OlympProject.WebApi.Models.Request;
using OlympProject.WebApi.Models.Response;
using System.Linq.Expressions;
using System.Net.WebSockets;

namespace OlympProject.WebApi.Repositories
{
    public class AnimalRepository : IAnimal
    {
        private readonly AppDBContext context;

        public AnimalRepository(AppDBContext context)
        {
            this.context = context;
        }

        public bool Create(AnimalRequest animalRequest)
        {
            try
            {
                var animal = new Animal()
                {
                    Weight = animalRequest.Weight,
                    Length = animalRequest.Length,
                    Height = animalRequest.Height,
                    Gender = animalRequest.Gender,
                    ChipperId = animalRequest.ChipperId,
                    ChippingLocationId = animalRequest.ChippingLocationId,
                };
                context.Animals.Add(animal);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new InvalidDataException(ex.Message, ex);
            }
        }

        public bool Delete(long id)
        {
            try
            {
                var animal = Get(id);
                if (animal != null)
                {
                    context.Animals.Remove(animal);
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

        public Animal Get(long id)
        {
            try
            {
                var animal = context.Animals.SingleOrDefault(x => x.Id == id);
                if (animal != null)
                {
                    return animal;
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

        public List<Animal> Search(DateTime? startDateTime, DateTime? endDateTime, int? chipperId, long? chippingLocationId, string? lifeStatus, string? gender, int from = 0, int size = 10)
        {
            try
            {
                var animal = context.Animals.AsQueryable();

                if (startDateTime.HasValue && animal.Any())
                    animal = animal.Where(x => x.ChippingDateTime >= startDateTime.Value);

                if (endDateTime.HasValue && animal.Any())
                    animal = animal.Where(x => x.ChippingDateTime <= endDateTime.Value);

                if (chipperId > 0 && animal.Any())
                    animal = animal.Where(x => x.ChipperId == chipperId.Value);

                if (chippingLocationId > 0 && animal.Any())
                    animal = animal.Where(x => x.ChippingLocationId == chippingLocationId.Value);

                if (!string.IsNullOrEmpty(lifeStatus) && animal.Any())
                    animal = animal.Where(x => x.LifeStatus.Equals(lifeStatus));

                if (!string.IsNullOrEmpty(gender) && animal.Any())
                    animal = animal.Where(x => x.Gender.Equals(gender));

                animal = animal.OrderBy(x => x.Id).Skip(from).Take(size);
                return animal.ToList();
            }
            catch(Exception ex)
            {
                throw new InvalidDataException(ex.Message, ex);
            }
        }

        public bool Update(long id, AnimalRequest animalRequest)
        {
            try
            {
                var animal = Get(id);
                if (animal != null)
                {
                    animal.Weight = animalRequest.Weight;
                    animal.Length = animalRequest.Length;
                    animal.Height = animalRequest.Height;
                    animal.Gender = animalRequest.Gender;
                    animal.LifeStatus = animalRequest.LifeStatus;
                    animal.ChipperId = animalRequest.ChipperId;
                    animal.ChippingLocationId = animalRequest.ChippingLocationId;
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    throw new InvalidDataException("Не найдено");
                }
            }
            catch (Exception ex)
            {
                throw new InvalidDataException(ex.Message, ex);
            }
        }

        public bool AddAnimalType(long id, long typeid)
        {
            try
            {
                var animal = Get(id);
                var type = context.AnimalTypes.FirstOrDefault(x => x.Id == typeid);
                if( animal != null && type != null)
                {
                    animal.AnimalTypes.Add(type);
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

        public bool UpdateAnimalType(long id, TypeRequest typeRequest)
        {
            try
            {
                var animal = context.Animals.Include(s => s.AnimalTypes).FirstOrDefault(x => x.Id == id);
                var oldtype = context.AnimalTypes.FirstOrDefault(x => x.Id == typeRequest.OldTypeId);
                var newtype = context.AnimalTypes.FirstOrDefault(x => x.Id == typeRequest.NewTypeId);
                if (animal != null && oldtype != null && newtype != null)
                {
                    animal.AnimalTypes.Remove(oldtype);
                    animal.AnimalTypes.Add(newtype);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    throw new InvalidDataException("Не найдено");
                }
            }
            catch (Exception ex)
            {
                throw new InvalidDataException(ex.Message, ex);
            } 
        }

        public bool DeleteAnimalType(long id, long typeid)
        {
            try
            {
                var animal = context.Animals.Include(s => s.AnimalTypes).FirstOrDefault(x => x.Id == id);
                var type = context.AnimalTypes.FirstOrDefault(x => x.Id == typeid);
                if (animal != null && type != null)
                {
                    animal.AnimalTypes.Remove(type);
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

        public bool AddAnimalLocation(long id, long locationid)
        {
            var animal = Get(id);
            var location = context.LocationPoints.FirstOrDefault(c => c.Id == locationid);
            if (animal != null && location != null)
            {
                animal.LocationPoints.Add(location);
                context.SaveChanges();
                return true;
            }
            else
            {
                throw new InvalidDataException("Не найдено");
            }
        }

        public bool UpdateAnimalLocation(long id, LocationRequest request)
        {
            var animal = context.Animals.Include(x => x.LocationPoints).FirstOrDefault(c => c.Id == id);
            var oldlocation = context.LocationPoints.FirstOrDefault(x => x.Id == request.OldLocationId);
            var newlocation = context.LocationPoints.FirstOrDefault(x => x.Id == request.NewLocationId);
            if(animal != null && oldlocation != null && newlocation != null)
            {
                animal.LocationPoints.Remove(oldlocation);
                animal.LocationPoints.Add(newlocation);
                context.SaveChanges();
                return true;
            }
            else
            {
                throw new InvalidDataException("Не найдено");
            }
        }

        public bool DeleteAnimalLocation(long id, long locationid)
        {
            var animal = context.Animals.Include(x => x.LocationPoints).FirstOrDefault(c => c.Id == id);
            var location = context.LocationPoints.FirstOrDefault(c => c.Id == locationid);
            if(animal != null && location != null)
            {
                animal.LocationPoints.Remove(location);
                context.SaveChanges();
                return true;
            }
            else
            {
                throw new InvalidDataException("Не найдено");
            }
        }
    }
}
