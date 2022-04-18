using System.ComponentModel.DataAnnotations;

namespace General.Models.Dtos
{
    public class ProductImageDto
    {
        [Key]
        public int ProductImageID { get; set; }
        public string? ImageLink { get; set; }
        public Product? Product { get; set; }
    }
}
