using System.ComponentModel.DataAnnotations;

namespace General.Models
{
    public class CartItem
    {
        [Key]
        public int CartItemID { get; set; }
        [Required]
        public int Quantity { get; set; } = 1;
        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [Required]
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public Cart Cart { get; set; }
        public Product Product { get; set; }
    }
}
