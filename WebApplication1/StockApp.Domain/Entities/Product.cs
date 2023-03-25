using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Core.Domain.Entities
{
    public class Product
    {
        public int id { get; set; }

        public string productName { get; set; }

        public string productDescription { get; set; }

        public string productImg { get; set; }

        public double productPrice { get; set; }

        public int categoryId { get; set; }

        //navigation property
        public Categories categories { get; set; }
    }
}
