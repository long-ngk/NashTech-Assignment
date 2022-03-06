using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.Models.Dtos
{
    public class ProductImageDto
    {
        public int ProductImageID { get; set; }
        public string ImageLink { get; set; }
        public Product Product { get; set; }
    }
}
