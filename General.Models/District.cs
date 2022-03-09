using System.ComponentModel.DataAnnotations;

namespace General.Models
{
    public class District
    {
        [Key]
        public string DistrictID { get; set; }
        [Required]
        public string DistrictName { get; set; }
        public City City { get; set; }

        public ICollection<UserAddress> UserAddresses { get; set; }
    }
}
