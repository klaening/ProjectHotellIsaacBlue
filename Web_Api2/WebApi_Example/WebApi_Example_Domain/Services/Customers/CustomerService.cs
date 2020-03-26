using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi_Example_Domain.Models;
using WebApi_Example_Domain.Repository;

namespace WebApi_Example_Domain.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IEnumerable<Customers>> GetCustomers()
        {
            return await _customerRepository.GetCustomers();
        }

        public async Task<Customers> GetCustomer(int id)
        {
            return await _customerRepository.GetCustomer(id);
        }

        public async Task<bool> AddCustomer(Customers customer)
        {
            return await _customerRepository.AddCustomer(customer);
        }
    }
}
