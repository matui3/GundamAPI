using GundamAPI.Models;

namespace GundamAPI.Interfaces
{
	public interface IFeaturesRepository
	{
		public ICollection<Feature> GetFeatures();
		Feature GetFeature(int id);
		ICollection<Gundam> GetGundamsByFeatures(int featureId);
		bool FeaturesExists(int id);
	}
}
