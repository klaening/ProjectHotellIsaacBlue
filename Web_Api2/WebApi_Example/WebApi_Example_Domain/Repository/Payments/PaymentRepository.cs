using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using WebApi_Example_Domain.Models;

namespace WebApi_Example_Domain.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly string _connectionString;

        public PaymentRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<Payments>> GetPayments()
        {
            using (var c = new SqlConnection(_connectionString))
            {
                try
                {
                    return await c.QueryAsync<Payments>("SELECT * FROM PAYMENTS");
                }
                catch (System.Exception ex)
                {
                    var p = ex;
                    throw;
                }
            }
        }

        public async Task<Payments> GetPayment(int id)
        {
            using (var c = new SqlConnection(_connectionString))
            {
                return await c.QueryFirstOrDefaultAsync<Payments>("SELECT * FROM PAYMENTS WHERE ID = @id", new { id} );
            }
        }

        public async Task<bool> AddPayment(Payments payment)
        {
            using (var c = new SqlConnection(_connectionString))
            {
                try
                {
                    await c.ExecuteAsync("INSERT INTO PAYMENTS (TOTALCOST, TRANSACTIONTOKEN, BOOKINGSID, DISCOUNTMONEY, CUSTOMERSID) VALUES (@TotalCost, @TransactionToken, @BookingsID, @DiscountMoney, @CustomersID)", new { payment.TOTALCOST, payment.TRANSACTIONTOKEN, payment.BOOKINGSID, payment.DISCOUNTMONEY, payment.CUSTOMERSID });
                    return true;
                }
                catch (System.Exception)
                {
                    return false;
                }

            }
        }
    }
}
