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
        public ActionResult<Account> Get(int id)
        {
            var responses = account.Get(id);
            return Ok(responses);
        }

        [HttpGet, Route("accounts/search")]
        public ActionResult<List<Account>> Search(string? firstName, string? lastName, string? email, int from = 0, int size = 10)
        {
            var accounts = account.Search(firstName, lastName, email, from, size);
            return Ok(accounts);
        }

        [HttpPut, Route("accounts/{id}")]
        public void Update(int id, AccountRequest accountRequest)
        {
            account.Update(id, accountRequest);
        }

        [HttpDelete, Route("accounts/{id}")]
        public void Delete(int id)
        {
            account.Delete(id);
        }

    }
}
