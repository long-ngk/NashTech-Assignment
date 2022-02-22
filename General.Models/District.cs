using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
