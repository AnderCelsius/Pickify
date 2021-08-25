using Newtonsoft.Json;
using Pickify.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Pickify.Data
{
    public class Seeder
    {
        public Seeder(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment webHostEnvironment { get; }

        public string GetPath(string folderName, string fileName)
        {
            return Path.Combine(webHostEnvironment.WebRootPath, folderName, fileName);
        }

        public async Task SeedData(AppDbContext context)
        {
            try
            {
                context.Database.EnsureCreated();
                if (!context.Customers.Any())
                {
                    var customerData = File.ReadAllText(GetPath("Data", "Customers.json"));
                    var listOfCustomers = JsonConvert.DeserializeObject<List<Customer>>(customerData);
                    await context.Customers.AddRangeAsync(listOfCustomers);
                }
                if (!context.Suppliers.Any())
                {
                    var supplierData = File.ReadAllText(GetPath("Data", "Suppliers.json"));
                    var listOfSuppliers = JsonConvert.DeserializeObject<List<Supplier>>(supplierData);
                    await context.Suppliers.AddRangeAsync(listOfSuppliers);
                }
                if (!context.Shippers.Any())
                {
                    var shippersData = File.ReadAllText(GetPath("Data", "Shippers.json"));
                    var listOfShippers = JsonConvert.DeserializeObject<List<Shipper>>(shippersData);
                    await context.Shippers.AddRangeAsync(listOfShippers);
                }
                if (!context.Categories.Any())
                {
                    var categoriesData = File.ReadAllText(GetPath("Data", "Categories.json"));
                    var listOfCategories = JsonConvert.DeserializeObject<List<Category>>(categoriesData);
                    await context.Categories.AddRangeAsync(listOfCategories);
                }
                if (!context.OrderDetails.Any())
                {
                    var orderDetailsData = File.ReadAllText(GetPath("Data", "OrderDetails.json"));
                    var listOfOrders = JsonConvert.DeserializeObject<List<OrderDetails>>(orderDetailsData);
                    await context.OrderDetails.AddRangeAsync(listOfOrders);
                }
                if (!context.Orders.Any())
                {
                    var ordersData = File.ReadAllText(GetPath("Data", "Orders.json"));
                    var orders = JsonConvert.DeserializeObject<List<Order>>(ordersData);
                    await context.Orders.AddRangeAsync(orders);
                }
                if (!context.Products.Any())
                {
                    var productData = File.ReadAllText(GetPath("Data", "Products.json"));
                    var listOfProducts = JsonConvert.DeserializeObject<List<Product>>(productData);
                    await context.Products.AddRangeAsync(listOfProducts);
                }
                //if (!context.ProductImages.Any())
                //{
                //    var productData = File.ReadAllText(buildDir + @"/JsonFiles/ProductImages.json");
                //    var listOfProductImages = JsonConvert.DeserializeObject<List<ProductImage>>(productData);
                //    await context.ProductImages.AddRangeAsync(listOfProductImages);
                //}


                context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
