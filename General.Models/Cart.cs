using System.ComponentModel.DataAnnotations;

namespace General.Models
{
    public class Cart
    {
        [Key]
        public int CartID { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [Required]
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public int UserID { get; set; }
        public User User { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
    }
}
