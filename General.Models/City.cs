using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
