using System.ComponentModel.DataAnnotations;

namespace General.Models
{
    public class OrderItem
    {
        [Key]
        public int OrderItemID { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [Required]
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
