using System.ComponentModel.DataAnnotations;

namespace General.Models
{
    public class Ward
    {
        [Key]
        public string WardID { get; set; }
        [Required]
        public string WardName { get; set; }
        public District District { get; set; }

        public ICollection<UserAddress> UserAddresses { get; set; }
    }
}
