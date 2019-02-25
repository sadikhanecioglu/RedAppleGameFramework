using RedApple.DomainNet35.result;
using RedApple.DomainNet35.status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedApple.DomainNet35.User
{
    public class LogoutUserResultModel : ResultModel
    {

        public LogoutUserResultModel(ResultStatus Status, string Message) : base(Status, Message)
        {

        }
    }
}
