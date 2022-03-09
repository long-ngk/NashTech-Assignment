using System.ComponentModel.DataAnnotations;

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
