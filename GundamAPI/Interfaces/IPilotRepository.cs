using GundamAPI.Models;

namespace GundamAPI.Interfaces
{
	public interface IPilotRepository
	{
		public ICollection<Pilot> GetPilots();
		Pilot GetPilot(int id);
		Gundam GetGundamOfAPilot(int pilotId);
		Pilot GetPilotByGundam(int gundamId);
		bool PilotExists(int id);

	}
}
