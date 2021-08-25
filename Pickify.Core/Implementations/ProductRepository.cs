using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pickify.Core.Interfaces;
using Pickify.Data;
using Pickify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickify.Core.Implementations
{
    public class ProductRepository : IProductRepository
    {
        AppDbContext context;
        public ProductRepository(IServiceProvider services)
        {
            context = services.GetRequiredService<AppDbContext>();
        }

        public Product GetAProduct(string id)
        {
            return context.Products.ToList()
                .SingleOrDefault(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await context.Products
                .Include(p => p.ProductImages).ToListAsync();
        }
    }
}
