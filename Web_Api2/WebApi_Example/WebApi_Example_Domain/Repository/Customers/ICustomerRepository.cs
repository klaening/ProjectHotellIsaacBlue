using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi_Example_Domain.Models;

namespace WebApi_Example_Domain.Repository
{
    public interface ICustomerRepository
    {
        Task<bool> AddCustomer(Customers customer, int accountID);
        Task<IEnumerable<Customers>> GetCustomers();
        Task<Customers> GetCustomer(int id);
    }
}
