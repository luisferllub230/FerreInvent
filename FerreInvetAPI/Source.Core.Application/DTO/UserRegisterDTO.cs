using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Core.Application.DTO
{
    public class UserRegisterDTO
    {
        public string UserNickName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string UserConfirmPassword { get; set; }
        public string position { get; set; }
    }
}
