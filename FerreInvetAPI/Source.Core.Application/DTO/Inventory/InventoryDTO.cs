﻿using Source.Core.Domain.Entities;
using Source.Core.Domain.ICommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Core.Application.DTO.Inventory
{
    public class InventoryDTO : IdEntityCommon
    {
        public int id { get; set; }
        public string inventoryName { get; set; }
        public int quantity { get; set; }
        public double price { get; set; }
        public double discount { get; set; }
        public string bran { get; set; }

        //TODO: NEED DTO sales
        public int salesCount { get; set; }

        public string categoryName { get; set; }
    }
}
