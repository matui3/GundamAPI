using GundamAPI.Interfaces;
using GundamAPI.Models;

namespace GundamAPI.Repository
{
	public class PilotRepository : IPilotRepository
	{
		public ICollection<Gundam> GetGundamByPilot(int pilotId)
		{
			throw new NotImplementedException();
		}

		public Pilot GetPilot(int id)
		{
			throw new NotImplementedException();
		}

		public ICollection<Pilot> GetPilotByGundam(int gundamId)
		{
			throw new NotImplementedException();
		}

		public ICollection<Pilot> GetPilots()
		{
			throw new NotImplementedException();
		}

		public bool PilotExists(int id)
		{
			throw new NotImplementedException();
		}
	}
}
