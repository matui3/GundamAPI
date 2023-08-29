using GundamAPI.Models;

namespace GundamAPI.Interfaces
{
	public interface IFactionRepository
	{
		public ICollection<Faction> GetFactions();
		Faction GetFaction(int id);
		Faction GetFactionByPilot(int pilotId);
		ICollection<Pilot> GetPilotsFromAFaction(int factionId);
		bool FactionExists(int id);
	}
}
