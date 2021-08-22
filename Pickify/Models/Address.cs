using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pickify.Models
{
    public class Address
    {
        public string Id { get; set; }
        [Required]
        [StringLength(10)]
        public string HouseNumber { get; set; }
        [Required]
        [StringLength(50)]
        public string Street { get; set; }
        [Required]
        [StringLength(50)]
        public string City { get; set; }
        [Required]
        [StringLength(50)]
        public string State { get; set; }
        public string PostalCode { get; set; }
        public ICollection<Customer> Customers { get; set; }
        public ICollection<Supplier> Suppliers { get; set; }
    }
}