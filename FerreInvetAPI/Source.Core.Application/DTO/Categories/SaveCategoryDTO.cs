using Source.Core.Domain.ICommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Core.Application.DTO.Categories
{
    public class SaveCategoryDTO : IdEntityCommon
    {
        public int id { get; set; }
        public string categoryName { get; set; }
    }
}
