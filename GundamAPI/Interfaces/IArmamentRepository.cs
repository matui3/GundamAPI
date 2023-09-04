using GundamAPI.Models;

namespace GundamAPI.Interfaces
{
	public interface IArmamentRepository
	{
		public ICollection<Armaments> GetArmaments();
		Armaments GetArmament(int id);

		ICollection<Gundam> GetGundamsByArmaments(int armamentId);
		
		bool ArmamentExists(int id);
	}
}
