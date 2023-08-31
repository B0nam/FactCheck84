using System.ComponentModel.DataAnnotations;

namespace FactCheck84.Models
{
    public class Text
    {
        public int Id { get; set; }
        [Required]
        public String Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public int AuthorId { get; set; }
        [Required]
        public int TextStatusId { get; set; }
        public string CensoredContent { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreationDate { get; set; }

        public Author Author { get; set; }
        public TextStatus TextStatus { get; set; }


        public Text()
        {
            CreationDate = DateTime.Now;
        }

                public Text(int id, String title, String description, String content, int authorId, int textStatusId)
                {
                    Id = id;
                    Title = title;
                    Description = description;
                    Content = content;
                    CensoredContent = content;
                    CreationDate = DateTime.Now;
                    AuthorId = authorId;
                    TextStatusId = textStatusId;
                }
    }

}
