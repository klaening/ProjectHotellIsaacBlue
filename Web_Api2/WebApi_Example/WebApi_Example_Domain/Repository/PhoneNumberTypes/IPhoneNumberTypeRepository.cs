using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi_Example_Domain.Models;

namespace WebApi_Example_Domain.Repository
{
    public interface IPhoneNumberTypeRepository
    {
        Task<IEnumerable<PhoneNumberTypes>> GetPhoneNumberTypes();
        Task<PhoneNumberTypes> GetPhoneNumberType(int id);
    }
}
