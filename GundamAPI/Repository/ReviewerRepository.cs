using GundamAPI.Interfaces;
using GundamAPI.Models;

namespace GundamAPI.Repository
{
	public class ReviewerRepository : IReviewerRepository
	{
		public Reviewer GetReviewer(int id)
		{
			throw new NotImplementedException();
		}

		public ICollection<Reviewer> GetReviewers()
		{
			throw new NotImplementedException();
		}

		public ICollection<Review> GetReviewsByReviewer(int reviewerId)
		{
			throw new NotImplementedException();
		}

		public bool ReviewerExists(int id)
		{
			throw new NotImplementedException();
		}
	}
}
