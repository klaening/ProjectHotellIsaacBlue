using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi_Example_Domain.Models;

namespace WebApi_Example_Domain.Services
{
    public interface IAccountService
    {
        Task<bool> AddAccount(Accounts accounts);
        Task<IEnumerable<Accounts>> GetAccounts();
        Task<Accounts> GetAccount(int id); 
        Task<Accounts> GetAccount(string userName, string password);
    }
}
