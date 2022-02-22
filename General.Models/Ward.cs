using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
