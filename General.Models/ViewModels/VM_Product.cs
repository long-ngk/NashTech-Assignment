using General.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.Models.ViewModels
{
    public class VM_Product
    {
        public ProductDto ProductDto { get; set; }
        public List<ProductImageDto> ProductImageDto { get; set; }
    }
}
