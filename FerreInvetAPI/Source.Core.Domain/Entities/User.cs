using Source.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Core.Domain.Entities
{
    public class User : AuditableBaseEntity
    {

        public string name { get; set; }
        public string position { get; set; }
        public string userNickname { get; set; }
        public string userPassword { get; set; }
    }
}
