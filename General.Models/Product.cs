using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        [Required]
        public string ProdName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string SKU { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [Required]
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public int Views { get; set; } = 0;

        public ProductCategory ProductCategory { get; set; }
        public ProductDiscount ProductDiscount { get; set; }
        public ICollection<ProductInventory> ProductInventories { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public ICollection<ProductImage> ProductImages { get; set; }
    }
}
