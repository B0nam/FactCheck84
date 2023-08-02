namespace FactCheck84.Models
{
	public class User
	{
		public int Id { get; set; }
		// public int AccountStatusId { get; set; }
		public String Name { get; set; }
		public String Password { get; set; }
		public DateTime CreationDate { get; set; }
		public String Address { get; set; }
		public String SocialNum { get; set; }
	}
}
