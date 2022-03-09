using System.ComponentModel.DataAnnotations;

namespace General.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime DayOfBirth { get; set; }
        [Required]
        public string Email { get; set; }
        public string ImageLink { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [Required]
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        [Required]
        public bool IsActive { get; set; }
        public ICollection<UserAddress> UserAddresses { get; set; }
        public Cart Cart { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
