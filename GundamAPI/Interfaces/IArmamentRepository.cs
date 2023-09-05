using GundamAPI.Models;

namespace GundamAPI.Interfaces
{
	public interface IArmamentRepository
	{
		public ICollection<Armament> GetArmaments();
		Armament GetArmament(int id);

		ICollection<Gundam> GetGundamsByArmaments(int armamentId);
		
		bool ArmamentExists(int id);
	}
}
