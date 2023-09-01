using GundamAPI.Models;

namespace GundamAPI.Interfaces
{
	public interface IFeaturesRepository
	{
		public ICollection<Features> GetFeatures();
		Features GetFeature(int id);
		ICollection<Gundam> GetGundamByFeatures(int featureId);
		bool FeaturesExists(int id);
	}
}
