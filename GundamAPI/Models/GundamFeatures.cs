namespace GundamAPI.Models
{
	public class GundamFeatures
	{
		public int GundamId { get; set; }
		public int FeatureId { get; set; }
		public Gundam Gundam { get; set; }
		public Features Features { get; set; }
	}
}
