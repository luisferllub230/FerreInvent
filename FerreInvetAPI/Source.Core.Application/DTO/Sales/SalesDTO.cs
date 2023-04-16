using Source.Core.Application.DTO.Custumer;
using Source.Core.Application.DTO.Inventory;
using Source.Core.Domain.Entities;
using Source.Core.Domain.ICommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Core.Application.DTO.Sales
{
    public class SalesDTO : IdEntityCommon
    {
        public int id { get; set; }
        public DateTime dateSales { get; set; }
        public int quantity { get; set; }
        public float totalCosto { get; set; }

        //TODO: change by DTO
        public CustumerDTO custumerDTO { get; set; }

        public InventoryDTO inventoryDTO { get; set; }
    }
}
