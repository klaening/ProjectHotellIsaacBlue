using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using WebApi_Example_Domain.Models;

namespace WebApi_Example_Domain.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly string _connectionString;

        public ReviewRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<Reviews>> GetReviews()
        {
            using (var c = new SqlConnection(_connectionString))
            {
                try
                {
                    return await c.QueryAsync<Reviews>("SELECT * FROM REVIEWS");
                }
                catch (System.Exception ex)
                {
                    var p = ex;
                    throw;
                }
            }
        }

        public async Task<Reviews> GetReview(int id)
        {
            using (var c = new SqlConnection(_connectionString))
            {
                return await c.QueryFirstOrDefaultAsync<Reviews>("SELECT * FROM REVIEWS WHERE ID = @id", new { id} );
            }
        }

        public async Task<bool> AddReview(Reviews reviews)
        {
            using (var c = new SqlConnection(_connectionString))
            {
                try
                {
                    await c.ExecuteAsync("INSERT INTO REVIEWS (CUSTOMERSID, RATING, CUSTOMERREVIEW, BOOKINGSID) VALUES (@CustomersID, @Rating, @CustomerReview, @BookingsID )", new { reviews.CUSTOMERSID, reviews.RATING, reviews.CUSTOMERREVIEW, reviews.BOOKINGSID });
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
