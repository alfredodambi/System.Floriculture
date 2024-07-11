using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Floriculture.Domain.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public DateTime Date { get; set; }
        public decimal totalValue {  get; set; }

        [ForeignKey("ClientId")]
        public Client client { get; set; }

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    }
}
