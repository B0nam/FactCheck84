namespace FactCheck84.Models
{
	public class RedactedWord
	{
		public int Id { get; set; }
		public int CensorChiefId { get; set; }
		public string Word { get; set; }
		public DateTime CreationDate { get; set; }

		public CensorChief CensorChief { get; set; } = null!;
	}
}
