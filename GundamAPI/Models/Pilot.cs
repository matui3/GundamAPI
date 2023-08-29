namespace GundamAPI.Models
{
	public class Pilot
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public Gundam Gundam { get; set; }
		public Show show { get; set; }

		public Faction Faction { get; set; }
	}
}
