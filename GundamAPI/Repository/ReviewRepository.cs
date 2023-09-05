using GundamAPI.Data;
using GundamAPI.Interfaces;
using GundamAPI.Models;

namespace GundamAPI.Repository
{
	public class ReviewRepository : IReviewRepository
	{
		private DataContext _context;
        public ReviewRepository(DataContext context)
        {
			_context = context;            
        }
        public Review GetReview(int id)
		{
			return _context.Reviews.Where(r => r.Id == id).FirstOrDefault();
		}

		public ICollection<Review> GetReviews()
		{
			return _context.Reviews.ToList();
		}

		public ICollection<Review> GetReviewsOfAGundam(int gundamId)
		{
			return _context.Reviews.Where(r => r.Gundam.Id == gundamId).ToList();		
		}

		public bool ReviewExists(int id)
		{
			return _context.Reviews.Any(r => r.Id == id);
		}
	}
}
