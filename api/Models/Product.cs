using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [MinLength(3, ErrorMessage = "This field should be have between 3 and 60 chars")]
        [MaxLength(60, ErrorMessage = "This field should be have between 3 and 60 chars")]
        public string Title { get; set; }

        [MaxLength(1024, ErrorMessage = "This field should be have maximus 1024 chars")]
        public string Description { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Range(1, int.MaxValue, ErrorMessage = "The price should be more than zero")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Category invalid")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}