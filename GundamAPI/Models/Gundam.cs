namespace GundamAPI.Models
{
	public class Gundam
	{
		public int Id { get; set; }
		public string Model { get; set; }
		public int FactionId { get; set; }
		public virtual Faction Faction { get; set; }
		public int PilotId { get; set; }
		public virtual Pilot Pilot { get; set; }
		public int ShowId { get; set; }
		public virtual Show Show { get; set; }
		public ICollection<Armaments> Armaments { get; set; }
		public ICollection<Feature> Features { get; set; }
		public ICollection<Review> Reviews { get; set; }
		public ICollection<GundamArmament> GundamArmaments { get; set; }
		public ICollection<GundamFeature> GundamFeatures { get; set; }
	}
}
