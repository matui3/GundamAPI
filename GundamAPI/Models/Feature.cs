namespace GundamAPI.Models
{
	public class Feature
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public ICollection<Gundam> Gundams { get; set; }
		public ICollection<GundamFeature> GundamFeatures { get; set; }
	}
}
