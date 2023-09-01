using GundamAPI.Models;

namespace GundamAPI.Interfaces
{
	public interface IPilotRepository
	{
		public ICollection<Pilot> GetPilots();
		Pilot GetPilot(int id);
		ICollection<Gundam> GetGundamByPilot(int pilotId);
		ICollection<Pilot> GetPilotByGundam(int gundamId);
		ICollection<Faction> GetFactionByPilot(int pilotId);
		bool PilotExists(int id);

	}
}
