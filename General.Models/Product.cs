using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace General.Models
{
    public class Product
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
        public int Views { get; set; } = 0;

        [ForeignKey("CategoryID")]
        public ProductCategory? ProductCategory { get; set; }
        public ICollection<ProductInventory>? ProductInventories { get; set; }
        public ICollection<ProductImage>? ProductImages { get; set; }
    }
}
