using GundamAPI.Data;
using GundamAPI.Interfaces;
using GundamAPI.Models;

namespace GundamAPI.Repository
{
	public class GundamRepository : IGundamRepository
	{
		private readonly DataContext _context;
        public GundamRepository(DataContext context)
        {
			_context = context;
        }
        public Gundam GetGundam(int id)
		{
			return _context.Gundams.Where(g => g.Id == id).FirstOrDefault();
		}

		public Gundam GetGundam(string model)
		{
			return _context.Gundams.Where(g => g.Model == model).FirstOrDefault();
		}

		public ICollection<Gundam> GetGundams()
		{
			return _context.Gundams.OrderBy(g => g.Id).ToList();
		}

		public bool GundamExists(int gundamId)
		{
			return _context.Gundams.Any(g => g.Id == gundamId);
		}
	}
}
