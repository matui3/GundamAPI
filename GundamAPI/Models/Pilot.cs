namespace GundamAPI.Models
{
	public class Pilot
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public Gundam Gundam { get; set; }
		public int ShowId { get; set; }
		public Show Show { get; set; }

		public Faction Faction { get; set; }     
	}
}
