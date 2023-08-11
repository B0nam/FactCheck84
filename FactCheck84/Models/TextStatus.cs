namespace FactCheck84.Models
{
    public class TextStatus
    {
        public int Id { get; set; }
        public string Status { get; set; }


        public TextStatus()
        {
        }

        public TextStatus(int id, string status)
        {
            Id = id;
            Status = status;
        }
    }
}
