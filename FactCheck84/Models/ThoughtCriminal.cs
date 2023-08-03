namespace FactCheck84.Models
{
	public class ThoughtCriminal
	{
		public int Id { get; set; }
		public int? UserId { get; set; }
		public User User { get; set; }
		public int CriminalStatusId { get; set; }
		public CriminalStatus CriminalStatus { get; set; } = null!;
		public int JusticeExecuterId { get; set; }
		public JusticeExecuter JusticeExecuter { get; set; } = null!;
		public int LocationId { get; set; }
		public Location? Location { get; set; }
		public String Description { get; set; }
		public DateTime WarrantyDate { get; set; }

		public ThoughtCriminal()
		{
		}
	}
}
