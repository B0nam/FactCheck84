namespace FactCheck84.Models
{
	public class Text
	{
		public int Id { get; set; }
		public int EditorOfficerId { get; set; }
		public EditorOfficer EditorOfficer { get; set; } = null!;
		public int TextStatusId { get; set; }
		public TextStatus TextStatus { get; set; } = null!;
		public String TextContent { get; set; }
		public DateTime CreationDate { get; set; }
	}
}
