using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Core.Domain.Entities
{
    public class Categories
    {
        public int id { get; set; }

        public string categoryName { get; set; }

        public string categoryDescription { get; set; }

        public ICollection<Product> products { get; set; }
    }
}
