using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communityclinic.Models
{
    internal class Inventoryitems
    {
        public int Id { get; set; }
        public string Item { get; set; }
        public DateTime DateAdded { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime Expiration { get; set; }
        public string Category { get; set; }
        public string Unit { get; set; }
        public string BatchNumber { get; set; }
        public string Manufacturer { get; set; }
        public string Supplier { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
    }
}
