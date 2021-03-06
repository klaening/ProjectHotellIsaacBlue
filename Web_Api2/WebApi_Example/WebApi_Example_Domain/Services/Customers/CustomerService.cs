﻿using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi_Example_Domain.Models;
using WebApi_Example_Domain.Repository;

namespace WebApi_Example_Domain.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IAccountRepository _accountRepository;

        public CustomerService(ICustomerRepository customerRepository, IAccountRepository accountRepository)
        {
            _customerRepository = customerRepository;
            _accountRepository = accountRepository;
        }

        public async Task<IEnumerable<Customers>> GetCustomers()
        {
            return await _customerRepository.GetCustomers();
        }

        public async Task<Customers> GetCustomer(int id)
        {
            return await _customerRepository.GetCustomer(id);
        }

        public async Task<bool> AddCustomer(Customers customer, int accountID)
        {
            await _customerRepository.AddCustomer(customer, accountID);

            var account = await _accountRepository.GetAccount(accountID);
            account.CUSTOMERSID = customer.ID;
            await _accountRepository.UpdateAccount(account);

            return true;
        }

        public async Task<bool> UpdateCustomer(Customers customer)
        {
            return await _customerRepository.UpdateCustomer(customer);
        }
    }
}
