namespace GundamAPI.Models
{
	public class Gundam
	{
		public int Id { get; set; }
		public string Model { get; set; }
		public Faction Faction { get; set; }
		public int PilotId { get; set; }
		public Pilot pilot { get; set; }
		public int ShowId { get; set; }
		public Show show { get; set; }
		public ICollection<Review> Reviews { get; set; }
		public ICollection<GundamArmament> GundamArmaments { get; set; }
		public ICollection<GundamFeatures> GundamFeatures { get; set; }
	}
}
