using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OlympProject.Helpers;
using OlympProject.WebApi.Interfaces;
using OlympProject.WebApi.Models.Request;

namespace OlympProject.WebApi.Controllers
{
    [Helpers.Authorize]
    [Route("")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IAccountService _accountService;
        private IMapper _mapper;

        public AuthenticationController(
            IAccountService accountService,
            IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
        }

        [Helpers.AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _accountService.Authenticate(model);
            return Ok(response);
        }

        [Helpers.AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register(RegisterRequest model)
        {
            _accountService.Register(model);
            return Ok(new { message = "Registration successful" });
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var account = _accountService.GetById(id);
            return Ok(account);
        }

    }
}
