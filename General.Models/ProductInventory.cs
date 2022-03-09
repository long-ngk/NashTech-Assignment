using System.ComponentModel.DataAnnotations;

namespace General.Models
{
    public class ProductInventory
    {
        [Key]
        public int InventoryID { get; set; }
        [Required]
        public int Total { get; set; }
        [Required]
        public int Remain { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [Required]
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        [Required]
        public bool IsActive { get; set; } = true;
        public Product Product { get; set; }
    }
}
