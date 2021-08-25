using Microsoft.EntityFrameworkCore;
using Pickify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pickify.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetails>().HasKey(sc => sc.Id);

            modelBuilder.Entity<Order>().HasMany(x => x.OrderDetails).WithOne(x => x.Order);

            modelBuilder.Entity<Product>().HasMany(x => x.OrderDetails).WithOne(x => x.Product);

            modelBuilder.Entity<Order>()
                        .HasOne<Customer>(s => s.Customer)
                        .WithMany(g => g.Orders)
                        .HasForeignKey(s => s.CustomerId);

            modelBuilder.Entity<Order>()
                       .HasOne<Shipper>(s => s.Shipper)
                       .WithMany(g => g.Orders)
                       .HasForeignKey(s => s.ShipperId);

            modelBuilder.Entity<Product>()
                        .HasOne<Category>(s => s.Category)
                        .WithMany(g => g.Products)
                        .HasForeignKey(s => s.CategoryId);

        }
    }

    
}
