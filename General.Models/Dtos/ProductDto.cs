using System.ComponentModel.DataAnnotations;

namespace General.Models.Dtos
{
    public class ProductDto
    {
        [Key]
        public int ProductID { get; set; }
        [Required]
        public string? ProductName { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [Required]
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public int Views { get; set; }

        public int CategoryID { get; set; }
        public ProductCategory? ProductCategory { get; set; }
        public ICollection<ProductInventory>? ProductInventories { get; set; }
        public List<ProductImage>? ProductImages { get; set; }
    }
}
