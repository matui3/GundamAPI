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
			throw new NotImplementedException();
		}

		public Gundam GetGundam(string model)
		{
			throw new NotImplementedException();
		}

		public ICollection<Gundam> GetGundams()
		{
			throw new NotImplementedException();
		}

		public bool GundamExists(int gundamId)
		{
			throw new NotImplementedException();
		}
	}
}
