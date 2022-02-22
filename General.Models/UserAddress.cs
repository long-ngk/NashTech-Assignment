using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.Models
{
    public class UserAddress
    {
        [Key]
        public int UserAddressID { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string MobilePhone { get; set; }
        public User User { get; set; }
        public Ward Ward { get; set; }
        public District District { get; set; }
        public City City { get; set; }
    }
}
