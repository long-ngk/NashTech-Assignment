using General.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAddress>()
                .HasOne(uA => uA.User)
                .WithMany(u => u.UserAddresses)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<UserAddress>()
                .HasOne(w => w.Ward)
                .WithMany(u => u.UserAddresses)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<UserAddress>()
                .HasOne(w => w.District)
                .WithMany(u => u.UserAddresses)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<UserAddress>()
                .HasOne(w => w.City)
                .WithMany(u => u.UserAddresses)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Product>()
                .HasOne(p => p.ProductDiscount)
                .WithMany(pd => pd.Products)
                .OnDelete(DeleteBehavior.Restrict);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Ward> Wards { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<AdminType> AdminTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductInventory> ProductInventories { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductDiscount> ProductDiscounts { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
