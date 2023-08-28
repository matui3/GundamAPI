namespace GundamAPI.Models
{
	public class Show
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime ReleaseDate { get; set; }
		public int Episodes { get; set; }
		public ICollection<Gundam> Gundams { get; set; }
		public ICollection<Pilot> Pilots { get; set; }
	}
}
