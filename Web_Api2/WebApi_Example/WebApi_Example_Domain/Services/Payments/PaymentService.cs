using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi_Example_Domain.Models;
using WebApi_Example_Domain.Repository;

namespace WebApi_Example_Domain.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<IEnumerable<Payments>> GetPayments()
        {
            return await _paymentRepository.GetPayments();
        }

        public async Task<Payments> GetPayment(int id)
        {
            return await _paymentRepository.GetPayment(id);
        }

        public async Task<bool> AddPayment(Payments payment)
        {
            return await _paymentRepository.AddPayment(payment);
        }
    }
}
