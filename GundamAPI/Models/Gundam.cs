namespace GundamAPI.Models
{
	public class Gundam
	{
		public int Id { get; set; }
		public string Model { get; set; }
		public Pilot pilot { get; set; }
		public Faction Faction { get; set; }
		public Show show { get; set; }
		public ICollection<Armaments> Armaments { get; set; }
		public ICollection<Features> Features { get; set; }
		public ICollection<Review> Reviews { get; set; }
		public ICollection<GundamArmament> GundamArmaments { get; set; }
		public ICollection<GundamFeatures> GundamFeatures { get; set; }
	}
}
