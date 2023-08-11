namespace FactCheck84.Models
{
    public class AuthorStatus
    {
        public int Id { get; set; }
        public string Status { get; set; }

        public AuthorStatus()
        {
        }

        public AuthorStatus(int id, string status)
        {
            Id = id;
            Status = status;
        }
    }
}
