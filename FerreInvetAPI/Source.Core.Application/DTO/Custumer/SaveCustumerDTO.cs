using Source.Core.Domain.ICommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Core.Application.DTO.Custumer
{
    public class SaveCustumerDTO : IdEntityCommon
    {
        public int id { get; set; }
        public string custumerName { get; set; }
        public string custumerAddress { get; set; }
        public string custumerEmail { get; set; }
    }
}
