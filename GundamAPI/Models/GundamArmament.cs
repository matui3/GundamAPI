﻿namespace GundamAPI.Models
{
	public class GundamArmament
	{
		public int GundamId { get; set; }
		public int ArmamentId { get; set; }
		public Gundam Gundam { get; set; }
		public Armament Armaments { get; set; }
	}
}
