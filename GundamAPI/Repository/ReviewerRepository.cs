using GundamAPI.Data;
using GundamAPI.Interfaces;
using GundamAPI.Models;

namespace GundamAPI.Repository
{
	public class ReviewerRepository : IReviewerRepository
	{
		private DataContext _context;
        public ReviewerRepository(DataContext context)
        {
             _context = context;
        }
        public Reviewer GetReviewer(int id)
		{
			return _context.Reviewers.Where(r => r.Id == id).FirstOrDefault();
		}

		public ICollection<Reviewer> GetReviewers()
		{
			return _context.Reviewers.ToList();
		}

		public ICollection<Review> GetReviewsByReviewer(int reviewerId)
		{
			return _context.Reviews.Where(r => r.Reviewer.Id == reviewerId).ToList();
		}

		public bool ReviewerExists(int id)
		{
			return _context.Reviewers.Any(r => r.Id == id);
		}
	}
}
