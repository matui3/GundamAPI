using GundamAPI.Models;

namespace GundamAPI.Interfaces
{
	public interface IReviewRepository
	{
		public ICollection<Review> GetReviews();
		Review GetReview(int id);
		ICollection<Review> GetReviewsOfAGundam(int gundamId);
		bool ReviewExists(int id);
	}
}
