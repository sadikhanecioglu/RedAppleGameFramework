using RedApple.DomainNet35.result;
using RedApple.DomainNet35.status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedApple.DomainNet35.User
{
    public class RegisterUserResultModel : ResultModel
    {

        public RegisterUserResultModel(ResultStatus Status, string Message) : base(Status, Message)
        {

        }
        public RegisterUserResultModel(string Token, string Message = "")
        {
            this.ResultStatus = ResultStatus.Ok;
            this.Token = Token;
            this.Message = Message;
        }

        public string Token { get; set; }



    }
}
