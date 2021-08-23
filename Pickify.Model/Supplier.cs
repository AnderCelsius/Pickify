using System.ComponentModel.DataAnnotations;

namespace Pickify.Models
{
    public class Supplier
    {
        [StringLength(125)]
        public string Id { get; set; }
        [Required]
        [StringLength(125)]
        public string CompanyName { get; set; }
        [Required]
        [StringLength(50)]
        public string ContactFirstName { get; set; }
        public string ContactLastName { get; set; }
        public string ContactTitle { get; set; }
        [Required]
        [StringLength(15)]
        public string Phone { get; set; }
        public Address Address { get; set; }
    }
}