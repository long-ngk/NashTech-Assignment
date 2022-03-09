using System.ComponentModel.DataAnnotations;

namespace General.Models
{
    public class City
    {
        [Key]
        public string CityID { get; set; }
        [Required]
        public string CityName { get; set; }
        public ICollection<UserAddress> UserAddresses { get; set; }
    }
}
