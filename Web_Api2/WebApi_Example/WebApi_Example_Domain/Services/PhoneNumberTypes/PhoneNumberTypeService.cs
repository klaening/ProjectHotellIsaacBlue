using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi_Example_Domain.Models;
using WebApi_Example_Domain.Repository;

namespace WebApi_Example_Domain.Services
{
    public class PhoneNumberTypeService : IPhoneNumberTypeService
    {
        private readonly IPhoneNumberTypeRepository _phoneNumberTypeRepository;

        public PhoneNumberTypeService(IPhoneNumberTypeRepository phoneNumberTypeRepository)
        {
            _phoneNumberTypeRepository = phoneNumberTypeRepository;
        }

        public async Task<IEnumerable<PhoneNumberTypes>> GetPhoneNumberTypes()
        {
            return await _phoneNumberTypeRepository.GetPhoneNumberTypes();
        }

        public async Task<PhoneNumberTypes> GetPhoneNumberType(int id)
        {
            return await _phoneNumberTypeRepository.GetPhoneNumberType(id);
        }
    }
}
