using AutoMapper;
using OlympProject.WebApi.Models;
using OlympProject.WebApi.Models.Request;
using OlympProject.WebApi.Models.Response;

namespace OlympProject.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            CreateMap<Account, AuthenticateResponse>();

            CreateMap<RegisterRequest, Account>();
        }
    }
}
