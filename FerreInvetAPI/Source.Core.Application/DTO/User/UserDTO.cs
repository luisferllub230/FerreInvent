using Source.Core.Domain.ICommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Core.Application.DTO.User
{
    public class UserDTO : IdEntityCommon
    {
        public int id { get; set; }
        public string name { get; set; }
        public string position { get; set; }
        public string userNickname { get; set; }
        public string userEmail { get; set; }
    }
}
