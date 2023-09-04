namespace GundamAPI.Models
{
	public class GundamFeature
	{
		public int GundamId { get; set; }
		public int FeatureId { get; set; }
		public Gundam Gundam { get; set; }
		public Feature Feature { get; set; }
	}
}
