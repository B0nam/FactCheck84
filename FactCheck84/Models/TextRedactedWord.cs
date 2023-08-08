namespace FactCheck84.Models
{
    public class TextRedactedWord
    {
        public int Id { get; set; }
        public int TextId { get; set; }
        public int RedactedWordId { get; set; }
        public Text Text { get; set; }
        public RedactedWord RedactedWord { get; set; }

        public TextRedactedWord()
        {
        }
    }
}
