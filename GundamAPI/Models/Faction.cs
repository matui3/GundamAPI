namespace GundamAPI.Models
{
	public class Faction
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public virtual ICollection<Gundam> Gundams { get; set; }
		public virtual ICollection<Pilot> Pilots { get; set; }
	}
}
