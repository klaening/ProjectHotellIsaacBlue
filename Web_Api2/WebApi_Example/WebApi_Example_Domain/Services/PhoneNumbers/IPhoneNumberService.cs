using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi_Example_Domain.Models;

namespace WebApi_Example_Domain.Services
{
    public interface IPhoneNumberService
    {
        Task<bool> AddPhoneNumber(PhoneNumbers phoneNumber);
        Task<IEnumerable<PhoneNumbers>> GetPhoneNumbers();
        Task<PhoneNumbers> GetPhoneNumber(int id);
    }
}
