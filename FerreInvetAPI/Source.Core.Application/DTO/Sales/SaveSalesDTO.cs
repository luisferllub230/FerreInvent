using Source.Core.Domain.ICommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Core.Application.DTO.Sales
{
    public class SaveSalesDTO : IdEntityCommon
    {
        public int id { get; set; }
        public DateTime dateSales { get; set; }
        public int quantity { get; set; }
        public float totalCosto { get; set; }
        public int custumerID { get; set; }
        public int inventoryID { get; set; }
    }
}
