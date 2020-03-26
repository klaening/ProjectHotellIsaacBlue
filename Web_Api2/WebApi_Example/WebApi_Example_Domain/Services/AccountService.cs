using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi_Example_Domain.Models;
using WebApi_Example_Domain.Repository;

namespace WebApi_Example_Domain.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<IEnumerable<Accounts>> GetAccounts()
        {
            return await _accountRepository.GetAccounts();
        }

        public async Task<Accounts> GetAccount(int id)
        {
            return await _accountRepository.GetAccount(id);
        }

        public async Task<bool> AddAccount(Accounts accounts)
        {
            return await _accountRepository.AddAccount(accounts);
        }
    }
}

