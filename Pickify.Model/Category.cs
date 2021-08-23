using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pickify.Models
{
    public class Category
    {
        [StringLength(125)]
        public string Id { get; set; }
        [Required]
        [StringLength(50)]
        public string CategoryName { get; set; }
        [StringLength(250)]
        public string Description { get; set; }
        public ICollection<Product> Products { get; set; }
        public bool Active { get; set; }
    }
}