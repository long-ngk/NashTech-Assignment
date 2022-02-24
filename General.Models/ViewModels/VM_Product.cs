using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.Models.ViewModels
{
    public class VM_Product
    {
        public Product Product { get; set; }
        public List<ProductImage> ProductImages { get; set; }
    }
}
