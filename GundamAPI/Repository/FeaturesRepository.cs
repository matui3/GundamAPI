using GundamAPI.Interfaces;
using GundamAPI.Models;

namespace GundamAPI.Repository
{
	public class FeaturesRepository : IFeaturesRepository
	{
		public bool FeaturesExists(int id)
		{
			throw new NotImplementedException();
		}

		public Features GetFeature(int id)
		{
			throw new NotImplementedException();
		}

		public ICollection<Features> GetFeatures()
		{
			throw new NotImplementedException();
		}

		public ICollection<Gundam> GetGundamByFeatures(int featureId)
		{
			throw new NotImplementedException();
		}
	}
}
