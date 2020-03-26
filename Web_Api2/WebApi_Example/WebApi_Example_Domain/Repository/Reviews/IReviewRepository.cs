using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi_Example_Domain.Models;

namespace WebApi_Example_Domain.Repository
{
    public interface IReviewRepository
    {
        Task<bool> AddReview(Reviews review);
        Task<IEnumerable<Reviews>> GetReviews();
        Task<Reviews> GetReview(int id);
    }
}
