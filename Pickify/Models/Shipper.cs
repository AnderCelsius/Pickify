using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pickify.Models
{
    public class Shipper
    {
        [StringLength(125)]
        public string Id { get; set; }
        [Required]
        [StringLength(125)]
        public string CompanyName { get; set; }
        [Required]
        [StringLength(15)]
        public string Phone { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}