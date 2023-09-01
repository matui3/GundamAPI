using GundamAPI.Models;

namespace GundamAPI.Interfaces
{
	public interface IShowRepository
	{
		public ICollection<Show> GetShows();
		Show GetShow(int id);
		ICollection<Gundam> GetGundamsByShow(int showId);
		ICollection<Pilot> GetPilotsByShow(int showId);
	}
}
