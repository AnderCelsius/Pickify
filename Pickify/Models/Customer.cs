using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pickify.Models
{
    public class Customer
    {
        [StringLength(125)]
        public string Id { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [StringLength(15)]
        public string Phone { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Address Address { get; set; }
        public ICollection<Order> Orders { get; set; }

        public Customer()
        {
            CreatedAt = DateTime.Now;
        }
    }
}
