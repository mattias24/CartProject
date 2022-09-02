using CartProject.Data.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CartProject.Models
{
    public class Products
    {
        public long Id { get; set; }

        [Required(ErrorMessage ="Product name")]
        public string Name { get; set; }

        public string Slug { get; set; }

        [Required, MinLength(4, ErrorMessage = "Fill in description")]
        public string Description { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage ="Please enter a price")]
        [Column(TypeName ="decimal(8, 2)")]
        public decimal Price { get; set; }

        [Required, Range(1, int.MaxValue, ErrorMessage ="Choose category")]
        public long CategoryId { get; set; }
        public Category Category { get; set; }
        public string Image { get; set; }
       
        [NotMapped]
        [FileExtension]
        public IFormFile ImageUpload { get; set; }


    }
}
