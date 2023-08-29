using GundamAPI.Models;

namespace GundamAPI.Interfaces
{
	public interface IArmamentRepository
	{
		public ICollection<Armaments> GetArmaments();
		Armaments GetArmament(int id);
		
		bool ArmamentExists(int id);
	}
}
