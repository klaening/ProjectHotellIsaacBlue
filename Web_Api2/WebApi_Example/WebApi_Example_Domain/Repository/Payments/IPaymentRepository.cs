using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi_Example_Domain.Models;

namespace WebApi_Example_Domain.Repository
{
    public interface IPaymentRepository
    {
        Task<bool> AddPayment(Payments payment);
        Task<IEnumerable<Payments>> GetPayments();
        Task<Payments> GetPayment(int id);
    }
}
