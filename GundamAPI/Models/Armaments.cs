namespace GundamAPI.Models
{
	public class Armaments
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public ICollection<GundamArmament> GundamArmaments { get; set; }
	}
}
