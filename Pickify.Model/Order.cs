using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pickify.Models
{
    public class Order
    {
        [Required]
        [MaxLength(50)]
        public string Id { get; set; }
        public double SalesTax { get; set; }
        public double TotalAmount { get; set; }
        [Required]
        [StringLength(25)]
        public string Status { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime ShipDate { get; set; }
        public DateTime RequireDate { get; set; }
        public string CustomerId { get; set; }
        public string ShipperId { get; set; }
        public Customer Customer { get; set; }
        public Shipper Shipper { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}