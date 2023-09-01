using GundamAPI.Models;

namespace GundamAPI.Interfaces
{
	public interface IReviewerRepository
	{
		public ICollection<Reviewer> GetReviewers();
		Reviewer GetReviewer(int reviewerId);
		ICollection<Review> GetReviewsByReviewer(int reviewerId);
		bool ReviewerExists(int reviewerId);
	}
}
