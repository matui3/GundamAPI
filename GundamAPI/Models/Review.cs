﻿namespace GundamAPI.Models
{
	public class Review
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Text { get; set; }

		public int ReviewerId { get; set; }
		public int GundamId { get; set; }
	}
}
