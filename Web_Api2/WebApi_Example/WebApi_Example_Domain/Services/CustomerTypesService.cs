using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi_Example_Domain.Models;
using WebApi_Example_Domain.Repository;

namespace WebApi_Example_Domain.Services
{
    public class CustomerTypesService : ICustomerTypesService
    {
        private readonly ICustomerTypesRepository _customerTypesRepository;

        public CustomerTypesService(ICustomerTypesRepository customerTypesRepository)
        {
            _customerTypesRepository = customerTypesRepository;
        }

        public async Task<IEnumerable<CustomerTypes>> GetCustomerTypes()
        {
            return await _customerTypesRepository.GetCustomerTypes();
        }

        public async Task<CustomerTypes> GetCustomerType(int id)
        {
            return await _customerTypesRepository.GetCustomerType(id);
        }
    }
}
