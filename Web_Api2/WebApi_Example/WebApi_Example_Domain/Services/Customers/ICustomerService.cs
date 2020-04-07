using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi_Example_Domain.Models;

namespace WebApi_Example_Domain.Services
{
    public interface ICustomerService
    {
        Task<bool> AddCustomer(Customers customer, int accountID);
        Task<IEnumerable<Customers>> GetCustomers();
        Task<Customers> GetCustomer(int id);
    }
}
