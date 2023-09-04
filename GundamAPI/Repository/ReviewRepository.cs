using GundamAPI.Interfaces;
using GundamAPI.Models;

namespace GundamAPI.Repository
{
	public class ReviewRepository : IReviewRepository
	{
		public Review GetReview(int id)
		{
			throw new NotImplementedException();
		}

		public ICollection<Review> GetReviews()
		{
			throw new NotImplementedException();
		}

		public ICollection<Review> GetReviewsOfAGundam(int gundamId)
		{
			throw new NotImplementedException();
		}

		public bool ReviewExists(int id)
		{
			throw new NotImplementedException();
		}
	}
}
