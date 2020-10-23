using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [MinLength(3, ErrorMessage = "This field should be have between 3 and 60 chars")]
        [MaxLength(60, ErrorMessage = "This field should be have between 3 and 60 chars")]
        public string Title { get; set; }
    }
}