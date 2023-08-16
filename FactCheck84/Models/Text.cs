using System.ComponentModel.DataAnnotations;

namespace FactCheck84.Models
{
    public class Text
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} required")]
        public String Title { get; set; }
        [Required(ErrorMessage = "{0} required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "{0} required")]
        public string Content { get; set; }
        [Required(ErrorMessage = "{0} required")]
        public int AuthorId { get; set; }
        [Required(ErrorMessage = "{0} required")]
        public int TextStatusId { get; set; }
        public string CensoredContent { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreationDate { get; set; } = DateTime.Now;

        public Author Author { get; set; }
        public TextStatus TextStatus { get; set; }
        public ICollection<TextRedactedWord> TextRedactedWords { get; set; }


        public Text()
        {
        }

        public Text(int id, String title, String description, String content, int authorId, int textStatusId)
        {
            Id = id;
            Title = title;
            Description = description;
            Content = content;
            CensoredContent = content;      //start with the base text, the controller will generate a CensoredContent.
            AuthorId = authorId;
            TextStatusId = textStatusId;
        }
    }
}
