using System.ComponentModel.DataAnnotations;

namespace General.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        [Required]
        public double Total { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [Required]
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public User User { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
