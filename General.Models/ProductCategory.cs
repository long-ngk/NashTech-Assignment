using System.ComponentModel.DataAnnotations;

namespace General.Models
{
    public class ProductCategory
    {
        [Key]
        public int CategoryID { get; set; }
        [Required]
        public string CategoryName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [Required]
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        [Required]
        public bool IsActive { get; set; } = true;
        public ICollection<Product> Products { get; set; }
    }
}
