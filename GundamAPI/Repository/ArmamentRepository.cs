using GundamAPI.Data;
using GundamAPI.Interfaces;
using GundamAPI.Models;

namespace GundamAPI.Repository
{
	public class ArmamentRepository : IArmamentRepository
	{
		private DataContext _context;

        public ArmamentRepository(DataContext context)
        {
			_context = context;    
        }
        public Armament GetArmament(int id)
		{
			return _context.Armaments.Where(a => a.Id == id).FirstOrDefault();
		}

		public ICollection<Armament> GetArmaments()
		{
			return _context.Armaments.ToList();
		}

		public ICollection<Gundam> GetGundamsByArmaments(int armamentId)
		{
			return _context.GundamArmaments.Where(e => e.ArmamentId == armamentId).Select(c => c.Gundam).ToList();
		}
		public bool ArmamentExists(int id)
		{
			return _context.Armaments.Any(a => a.Id == id);
		}
	}
}
