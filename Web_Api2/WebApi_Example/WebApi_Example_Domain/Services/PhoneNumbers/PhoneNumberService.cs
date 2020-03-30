using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi_Example_Domain.Models;
using WebApi_Example_Domain.Repository;

namespace WebApi_Example_Domain.Services
{
    public class PhoneNumberService : IPhoneNumberService
    {
        private readonly IPhoneNumberRepository _phoneNumberRepository;

        public PhoneNumberService(IPhoneNumberRepository staffRepository)
        {
            _phoneNumberRepository = staffRepository;
        }

        public async Task<IEnumerable<PhoneNumbers>> GetPhoneNumbers()
        {
            return await _phoneNumberRepository.GetPhoneNumbers();
        }

        public async Task<PhoneNumbers> GetPhoneNumber(int id)
        {
            return await _phoneNumberRepository.GetPhoneNumber(id);
        }

        public async Task<bool> AddPhoneNumber(PhoneNumbers phoneNumbers)
        {
            return await _phoneNumberRepository.AddPhoneNumber(phoneNumbers);
        }
    }
}
