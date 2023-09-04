using GundamAPI.Interfaces;
using GundamAPI.Models;

namespace GundamAPI.Repository
{
	public class ShowRepository : IShowRepository
	{
		public ICollection<Gundam> GetGundamsByShow(int showId)
		{
			throw new NotImplementedException();
		}

		public ICollection<Pilot> GetPilotsByShow(int showId)
		{
			throw new NotImplementedException();
		}

		public Show GetShow(int id)
		{
			throw new NotImplementedException();
		}

		public ICollection<Show> GetShows()
		{
			throw new NotImplementedException();
		}

		public bool ShowExists(int id)
		{
			throw new NotImplementedException();
		}
	}
}
