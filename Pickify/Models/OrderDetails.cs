using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pickify.Models
{
    public class OrderDetails
    {
        [Key]
        public string Id { get; set; }
        [Required]
        [MaxLength(50)]
        [ForeignKey("Order")]
        public string OrderId { get; set; }
        [Required]
        [MaxLength(125)]
        [ForeignKey("Product")]
        public string ProductId { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string PaymentMethod { get; set; }
    }
}