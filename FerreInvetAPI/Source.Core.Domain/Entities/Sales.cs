using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Core.Domain.Entities
{
    public class Sales
    {
        public int id { get; set; }
        public DateTime dateSales { get; set; }
        public int quantity { get; set; }
        public float totalCosto { get; set; } 
        
        //CUSTUMER
        public int custumerID { get; set; }
        public Custumers custumer { get; set; }

        //INVENTORY
        public int inventoryID { get; set; }
        public Inventory inventory { get; set; }
    }
}
