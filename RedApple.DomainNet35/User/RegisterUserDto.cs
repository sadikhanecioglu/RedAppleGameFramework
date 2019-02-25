using RedApple.DomainNet35.Dto;
using RedApple.DomainNet35.status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedApple.DomainNet35.User
{
    public class RegisterUserDto : IDtoNet35
    {

        public string UserName { get; set; }


        public string Name { get; set; }


        public string Surname { get; set; }


        public string EmailAddress { get; set; }
        public string Phone { get; set; }


        public string Password { get; set; }


        public string Token { get; set; }

        public OpenSessionType RegisterType { get; set; }

        

    }
}
