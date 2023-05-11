using AutoMapper;
using OlympProject.Database;
using OlympProject.Helpers;
using OlympProject.WebApi.Interfaces;
using OlympProject.WebApi.Models;
using OlympProject.WebApi.Models.Request;
using OlympProject.WebApi.Models.Response;

namespace OlympProject.WebApi.Repositories
{
    public class AccountService : IAccountService
    {
        private AppDBContext _context;
        private IJwtUtils _jwtUtils;
        private readonly IMapper _mapper;

        public AccountService(
            AppDBContext context,
            IJwtUtils jwtUtils,
            IMapper mapper)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _mapper = mapper;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var account = _context.Accounts.SingleOrDefault(x => x.Email == model.Email);

            if (account == null || !BCrypt.Net.BCrypt.Verify(model.Password, account.Password))
                throw new AppException("Email or password is incorrect");

            var response = _mapper.Map<AuthenticateResponse>(account);
            response.Token = _jwtUtils.GenerateToken(account);
            return response;
        }

        public Account GetById(int id)
        {
            return getAccount(id);
        }

        public void Register(RegisterRequest model)
        {
            if (_context.Accounts.Any(x => x.Email == model.Email))
                throw new AppException("Email '" + model.Email + "' is already taken");

            var account = _mapper.Map<Account>(model);

            account.Password = BCrypt.Net.BCrypt.HashPassword(model.Password);

            _context.Accounts.Add(account);
            _context.SaveChanges();
        }

        private Account getAccount(int id)
        {
            var account = _context.Accounts.Find(id);
            if (account == null) throw new KeyNotFoundException("Account not found");
            return account;
        }
    }
}
