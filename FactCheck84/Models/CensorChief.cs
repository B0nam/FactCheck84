﻿namespace FactCheck84.Models
{
	public class CensorChief
	{
		public int Id { get; set; }
		public int UserId { get; set; }

		public User User { get; set; } = null!;
	}
}
