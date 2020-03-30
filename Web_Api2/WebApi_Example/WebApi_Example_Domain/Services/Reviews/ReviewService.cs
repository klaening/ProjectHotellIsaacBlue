using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi_Example_Domain.Models;
using WebApi_Example_Domain.Repository;

namespace WebApi_Example_Domain.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<IEnumerable<Reviews>> GetReviews()
        {
            return await _reviewRepository.GetReviews();
        }

        public async Task<Reviews> GetReview(int id)
        {
            return await _reviewRepository.GetReview(id);
        }

        public async Task<bool> AddReview(Reviews review)
        {
            return await _reviewRepository.AddReview(review);
        }
    }
}
