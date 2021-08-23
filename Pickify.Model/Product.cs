using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pickify.Models
{
    public class Product
    {
        [StringLength(125)]
        public string Id { get; set; }
        [Required]
        [StringLength(150)]
        public string ProductName { get; set; }
        public string Description { get; set; }

        [ForeignKey("Supplier")]
        public string SupplierId { get; set; }
        // public ICollection<ProductSupplier> ProductSuppliers { get; set; }

        [StringLength(125)]
        public string CategoryId { get; set; }
        public Category Category { get; set; }
        public double UnitPrice { get; set; }
        public decimal UnitWeight { get; set; }
        public int QuantityPerUnit { get; set; }
        public int QuantityInStock { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}