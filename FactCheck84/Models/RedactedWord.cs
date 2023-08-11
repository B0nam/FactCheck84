using System.ComponentModel.DataAnnotations;

namespace FactCheck84.Models
{
    public class RedactedWord
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} required")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} size should be between {2} and {1}")]
        public string Word { get; set; }
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} size should be between {2} and {1}")]
        public string? NewWord { get; set; }
        public bool IsHidden { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreationDate { get; set; } = DateTime.Now;

        public RedactedWord()
        {
        }

        public RedactedWord(int id, String word, String newWord, bool isHidden)
        {
            Id = id;
            Word = word;
            NewWord = newWord;
            IsHidden = isHidden;
        }
    }
}
