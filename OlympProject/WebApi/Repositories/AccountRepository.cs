using AutoMapper;
using AutoMapper.Configuration.Annotations;
using OlympProject.Database;
using OlympProject.WebApi.Interfaces;
using OlympProject.WebApi.Models;
using OlympProject.WebApi.Models.Request;
using OlympProject.WebApi.Models.Response;
using System.Data;

namespace OlympProject.WebApi.Repositories
{
    public class AccountRepository : IAccount
    {
        private readonly AppDBContext context;
        private readonly IMapper mapper;
        public AccountRepository(AppDBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void Delete(int id)
        {
            try
            {
                var account = Get(id);
                if (account != null)
                {
                    context.Accounts.Remove(account);
                    context.SaveChanges();
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

        public Account Get(int id)
        {
            try
            {
                var account = context.Accounts.Find(id);
                if (account != null)
                {
                    return account;
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

        public List<Account> Search(string? firstName, string? lastName, string? email, int from = 0, int size = 10)
        {
            try
            {
                var accounts = context.Accounts.AsQueryable();

                if (!string.IsNullOrEmpty(firstName) && accounts.Any())
                    accounts = accounts.Where(x => x.FirstName.ToLower().Contains(firstName.ToLower()));

                if (!string.IsNullOrEmpty(lastName) && accounts.Any())
                    accounts = accounts.Where(x => x.LastName.ToLower().Contains(lastName.ToLower()));

                if (!string.IsNullOrEmpty(email) && accounts.Any())
                    accounts = accounts.Where(x => x.Email.ToLower().Contains(email.ToLower()));

                accounts = accounts.OrderBy(x => x.Id).Skip(from).Take(size);
                return accounts.ToList();
            }
            catch (Exception ex)
            {
                throw new InvalidDataException(ex.Message, ex);
            }
        }

        public AccountResponse Update(int id, AccountRequest accountRequest)
        {
            try
            {
                var account = Get(id);  
                if (account != null)
                {
                    account.FirstName = accountRequest.FirstName;
                    account.LastName = accountRequest.LastName;
                    account.Password = accountRequest.Password;
                    account.Email = accountRequest.Email;
                    context.SaveChanges();
                    var response = mapper.Map<AccountResponse>(account);
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
