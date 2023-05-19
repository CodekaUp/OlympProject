using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OlympProject.Database;
using OlympProject.WebApi.Interfaces;
using OlympProject.WebApi.Models;
using OlympProject.WebApi.Models.Request;
using OlympProject.WebApi.Models.Response;

namespace OlympProject.WebApi.Controllers
{
    [Route("")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccount account;
        public AccountController(IAccount account)
        {
            this.account = account;
        }

        [HttpGet, Route("accounts/{id}")]
        public IActionResult Get(int id)
        {
            var response = account.Get(id);
            return Ok(response);
        }

        [HttpGet, Route("accounts/search")]
        public IActionResult Search(string? firstName, string? lastName, string? email, int from = 0, int size = 10)
        {
            var response = account.Search(firstName, lastName, email, from, size);
            return Ok(response);
        }

        [HttpPut, Route("accounts/{id}")]
        public IActionResult Update(int id, AccountRequest accountRequest)
        {
            var response = account.Update(id, accountRequest);
            return Ok(response);
        }

        [HttpDelete, Route("accounts/{id}")]
        public IActionResult Delete(int id)
        {
            account.Delete(id);
            return Ok();
        }

    }
}
