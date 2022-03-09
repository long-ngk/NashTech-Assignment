using System.ComponentModel.DataAnnotations;

namespace General.Models
{
    public class ProductImage
    {
        [Key]
        public int ProductImageID { get; set; }
        [Required]
        public string ImageLink { get; set; }
        public Product Product { get; set; }
    }
}
