using GundamAPI.Data;
using GundamAPI.Interfaces;
using GundamAPI.Models;

namespace GundamAPI.Repository
{
	public class FactionRepository : IFactionRepository
	{
		private DataContext _context;
        public FactionRepository(DataContext context)
        {
			_context = context;
        }
        
		public Faction GetFaction(int id)
		{
			return _context.Factions.Where(f => f.Id == id).FirstOrDefault();
		}

		public ICollection<Faction> GetFactions()
		{
			return _context.Factions.ToList();
		}

		public Faction GetFactionByPilot(int pilotId)
		{
			return _context.Pilots.Where(p => p.Id == pilotId).Select(f => f.Faction).FirstOrDefault();
		}

		public ICollection<Pilot> GetPilotsFromAFaction(int factionId)
		{
			return _context.Pilots.Where(p => p.Faction.Id == factionId).ToList();
		}

		public bool FactionExists(int id)
		{
			return _context.Factions.Any(f => f.Id == id);
		}
	}
}
