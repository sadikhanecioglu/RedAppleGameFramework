using RedApple.DomainNet35.Dto;
using RedApple.DomainNet35.status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedApple.DomainNet35.Session
{
    public class OpenSessionDto : IDtoNet35
    {
        public OpenSessionDto()
        {

        }
        public OpenSessionDto(string UserName, string Password)
        {
            this.OpenSessionType = OpenSessionType.UserNamePassword;
            this.UserName = UserName;
            this.UserPassword = Password;
        }
        public OpenSessionDto(OpenSessionType Type, string Token)
        {
            this.OpenSessionType = Type;
            this.Token = Token;
        }

        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string Token { get; set; }
        public OpenSessionType OpenSessionType { get; set; }


    }


}
