using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.Models
{
    public class ProductImage
    {
        [Key]
        public int ProductImageID { get; set; }
        [Required]
        public string ImageLink { get; set; }
        public Product Product { get; set; }
    }
}
