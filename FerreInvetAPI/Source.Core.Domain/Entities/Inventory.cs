using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Core.Domain.Entities
{
    public class Inventory
    {
        public int id { get; set; }
        public string inventoryName { get; set; }
        public int quantity { get; set; }
        public double price { get; set; }
        public double discount { get; set; }
        public string bran { get; set; }

        //Sales
        public ICollection<Sales> sales { get; set; }
        
        //Category
        public int categoryID { get; set; }
        public Categories categories { get; set; }
    }
}
