using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Core.Domain.Entities
{
    public class Categories
    {
        public int id { get; set; }
        public string categoryName { get; set; }

        //Inventory
        public ICollection<Inventory> inventories { get; set; }
    }
}
