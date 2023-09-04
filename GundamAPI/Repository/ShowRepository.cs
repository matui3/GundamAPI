using GundamAPI.Data;
using GundamAPI.Interfaces;
using GundamAPI.Models;

namespace GundamAPI.Repository
{
	public class ShowRepository : IShowRepository
	{
		private DataContext _context;
        public ShowRepository(DataContext context)
        {
			_context = context;
        }
        public ICollection<Gundam> GetGundamsByShow(int showId)
		{
			return _context.Gundams.Where(g => g.Show.Id == showId).ToList();
		}

		public ICollection<Pilot> GetPilotsByShow(int showId)
		{
			return _context.Pilots.Where(p => p.Show.Id == showId).ToList();
		}

		public Show GetShow(int id)
		{
			return _context.Shows.Where(s => s.Id == id).FirstOrDefault();
		}

		public ICollection<Show> GetShows()
		{
			return _context.Shows.ToList();
		}

		public bool ShowExists(int id)
		{
			return _context.Shows.Any(s => s.Id == id);
		}
	}
}
