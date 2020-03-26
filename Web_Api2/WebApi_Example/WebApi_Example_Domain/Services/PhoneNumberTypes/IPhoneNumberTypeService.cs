using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi_Example_Domain.Models;

namespace WebApi_Example_Domain.Services
{
    public interface IPhoneNumberTypeService
    {
        Task<IEnumerable<PhoneNumberTypes>> GetPhoneNumberTypes();
        Task<PhoneNumberTypes> GetPhoneNumberType(int id);
    }
}
