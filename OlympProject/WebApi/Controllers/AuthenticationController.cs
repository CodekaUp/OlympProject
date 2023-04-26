using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OlympProject.WebApi.Interfaces;
using OlympProject.WebApi.Models.Request;

namespace OlympProject.WebApi.Controllers
{
    [Authorize]
    [Route("")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAccount account;
        public AuthenticationController(IAccount account)
        {
            this.account = account;
        }

        //[HttpPost, Route("/registration")]
        //public ActionResult Authentication(AccountRequest accountRequest)
        //{

        //}
    }
}
