using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi_Example_Domain.Models;

namespace WebApi_Example_Domain.Services
{
    public interface IPaymentService
    {
        Task<bool> AddPayment(Payments payment);
        Task<IEnumerable<Payments>> GetPayments();
        Task<Payments> GetPayment(int id);
    }
}
