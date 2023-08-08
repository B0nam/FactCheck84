namespace FactCheck84.Models
{
    public class Text
    {
        public int Id { get; set; }
        public int TextStatusId { get; set; }
        public int AuthorId { get; set; }
        public String Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string CensoredContent { get; set; }
        public DateTime CreationDate { get; set; }
        public TextStatus TextStatus { get; set; }

        public ICollection<TextRedactedWord> TextRedactedWords { get; set; }

        public Text()
        {
        }
    }
}
