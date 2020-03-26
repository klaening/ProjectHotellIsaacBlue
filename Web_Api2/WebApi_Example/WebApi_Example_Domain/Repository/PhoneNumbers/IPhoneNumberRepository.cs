using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi_Example_Domain.Models;

namespace WebApi_Example_Domain.Repository
{
    public interface IPhoneNumberRepository
    {
        Task<bool> AddPhoneNumber(PhoneNumbers phonenumber);
        Task<IEnumerable<PhoneNumbers>> GetPhoneNumbers();
        Task<PhoneNumbers> GetPhoneNumber(int id);
    }
}
