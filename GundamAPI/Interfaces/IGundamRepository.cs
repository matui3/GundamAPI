using GundamAPI.Models;

namespace GundamAPI.Interfaces
{
	public interface IGundamRepository
	{
		ICollection<Gundam> GetGundams();
		Gundam GetGundam(int id);
		Gundam GetGundam(string model);
		bool GundamExists(int gundamId);
	}
}
