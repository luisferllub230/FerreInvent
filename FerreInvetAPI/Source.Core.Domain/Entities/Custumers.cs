using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Core.Domain.Entities
{
    public class Custumers
    {
        public int id { get; set; }
        public string custumerName { get; set; }
        public string custumerAddress { get; set; }
        public string custumerEmail { get; set; }

        //Sales
        public ICollection<Sales> sales { get; set; }
    }
}
