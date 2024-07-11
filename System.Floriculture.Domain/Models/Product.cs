using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Floriculture.Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int amount { get; set;}
        public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
    }
}
