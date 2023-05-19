using AutoMapper;
using Microsoft.Identity.Client;
using OlympProject.Database;
using OlympProject.WebApi.Interfaces;
using OlympProject.WebApi.Models;
using OlympProject.WebApi.Models.Request;
using OlympProject.WebApi.Models.Response;

namespace OlympProject.WebApi.Repositories
{
    public class LocationPointRepository : ILocationPoint
    {
        private readonly AppDBContext context;
        private readonly IMapper mapper;

        public LocationPointRepository(AppDBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;

        }

        public LocationPointResponse Create(LocationPointRequest locationPointRequest)
        {
            try
            {
                var locationPoint = new LocationPoint()
                {
                    Latitude = locationPointRequest.Latitude,
                    Longitude = locationPointRequest.Longitude,
                    DateTimeOfVisitLocationPoint = locationPointRequest.DateTimeOfVisitLocationPoint
                };
                context.LocationPoints.Add(locationPoint);
                context.SaveChanges();
                var response = mapper.Map<LocationPointResponse>(locationPoint);
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
                var locationpoint = Get(id);
                if (locationpoint != null)
                {
                    context.LocationPoints.Remove(locationpoint);
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

        public LocationPoint Get(long id)
        {
            try
            {
                var locationpoint = context.LocationPoints.SingleOrDefault(p => p.Id == id);
                if (locationpoint != null)
                {
                    return locationpoint;
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

        public LocationPointResponse Update(long id, LocationPointRequest locationPointRequest)
        {
            try
            {
                var locationpoint = Get(id);
                if (locationpoint != null)
                {
                    locationpoint.Longitude = locationPointRequest.Longitude;
                    locationpoint.Latitude = locationPointRequest.Latitude;
                    locationpoint.DateTimeOfVisitLocationPoint = locationPointRequest.DateTimeOfVisitLocationPoint;
                    context.SaveChanges();
                    var response = mapper.Map<LocationPointResponse>(locationpoint);
                    return response;
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
    }
}
