using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi_Example_Domain.Models;

namespace WebApi_Example_Domain.Repository
{
    public interface ICustomerTypeRepository
    {
        Task<IEnumerable<CustomerTypes>> GetCustomerTypes();
        Task<CustomerTypes> GetCustomerType(int id);
    }
}
