namespace GundamAPI.Models
{
	public class Features
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public Gundam Gundam { get; set; }
		public ICollection<GundamFeatures> GundamFeatures { get; set; }
	}
}
