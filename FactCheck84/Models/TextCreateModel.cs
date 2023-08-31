using System.ComponentModel.DataAnnotations;

namespace FactCheck84.Models
{
    public class TextCreateModel
    {
        [Required]
        public String Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Content { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreationDate { get; set; }

        public TextCreateModel()
        {
            CreationDate = DateTime.Now;
        }
    }


}
