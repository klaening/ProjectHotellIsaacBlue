using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi_Example_Domain.Models;

namespace WebApi_Example_Domain.Repository
{
    public interface ICustomerTypesRepository
    {
        Task<IEnumerable<CustomerTypes>> GetCustomerTypes();
        Task<CustomerTypes> GetCustomerType(int id);
    }
}
