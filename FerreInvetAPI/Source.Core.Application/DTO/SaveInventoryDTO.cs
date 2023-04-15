﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Core.Application.DTO
{
    public class SaveInventoryDTO
    {
        public int id { get; set; }
        public string inventoryName { get; set; }
        public int quantity { get; set; }
        public int price { get; set; }
        public int discount { get; set; }
        public string bran { get; set; }
        public int categoryId { get; set; }

    }
}
