namespace GundamAPI.Models
{
	public class Faction
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public ICollection<Pilot> Pilots { get; set; }
		public ICollection<Gundam> Gundams { get; set; }
	}
}
