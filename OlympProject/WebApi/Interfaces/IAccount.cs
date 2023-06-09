﻿using OlympProject.WebApi.Models;
using OlympProject.WebApi.Models.Request;
using OlympProject.WebApi.Models.Response;

namespace OlympProject.WebApi.Interfaces
{
    public interface IAccount
    {
        public Account Get(int id);
        public AccountResponse Update(int id, AccountRequest accountRequest);
        public void Delete(int id);
        public List<Account> Search(string? firstName, string? lastName, string? email, int from = 0, int size = 10);
       
    }
}
