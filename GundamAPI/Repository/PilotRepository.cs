using GundamAPI.Data;
using GundamAPI.Interfaces;
using GundamAPI.Models;

namespace GundamAPI.Repository
{
	public class PilotRepository : IPilotRepository
	{
		private DataContext _context;
        public PilotRepository(DataContext context)
        {
            _context = context;
        }
        public Gundam GetGundamOfAPilot(int pilotId)
		{
			return _context.Pilots.Where(p => p.Id == pilotId).Select(g => g.Gundam).FirstOrDefault();
		}

		public Pilot GetPilot(int id)
		{
			return _context.Pilots.Where(p => p.Id == id).FirstOrDefault();
		}

		public Pilot GetPilotByGundam(int gundamId)
		{
			return _context.Gundams.Where(g => g.Id == gundamId).Select(p => p.Pilot).FirstOrDefault();
		}

		public ICollection<Pilot> GetPilots()
		{
			return _context.Pilots.ToList();
		}

		public bool PilotExists(int id)
		{
			return _context.Pilots.Any(p => p.Id == id);
		}
	}
}
