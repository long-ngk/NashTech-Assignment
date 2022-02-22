using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.Models
{
    public class AdminType
    {
        [Key]
        public int AdminTypeID { get; set; }
        [Required]
        public string Permission { get; set; }
        public string Note { get; set; }
        public ICollection<Admin> Admins { get; set; }
    }
}
