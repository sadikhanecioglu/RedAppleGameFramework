using RedApple.DomainNet35.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedApple.DomainNet35.User
{
    public class UpdateUserDto : IDtoNet35
    {
        public string Email { get; set; }
        public string OldPassword { get; set; }
        public string NewPassWord { get; set; }

    }
}
