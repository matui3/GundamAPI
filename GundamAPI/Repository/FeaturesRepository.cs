using GundamAPI.Data;
using GundamAPI.Interfaces;
using GundamAPI.Models;

namespace GundamAPI.Repository
{
	public class FeaturesRepository : IFeaturesRepository
	{
		private DataContext _context;
        public FeaturesRepository(DataContext context)
        {
            _context = context;
        }

        public Feature GetFeature(int id)
		{
			return _context.Features.Where(f => f.Id == id).FirstOrDefault();
		}

		public ICollection<Feature> GetFeatures()
		{
			return _context.Features.ToList();
		}

		public ICollection<Gundam> GetGundamsByFeatures(int featureId)
		{
			return _context.GundamFeatures.Where(e => e.FeatureId == featureId).Select(c => c.Gundam).ToList();
		}

		public bool FeaturesExists(int id)
		{
			throw new NotImplementedException();
		}
	}
}
