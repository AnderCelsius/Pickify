using System.Collections.Generic;

namespace Pickify.Models
{
    public class ProductImage
    {
        public string Id { get; set; }
        public string URL { get; set; }
        public string ProductId { get; set; }
        public Product Product { get; set; }
    }
}