using RedApple.DomainNet35.result;
using RedApple.DomainNet35.status;
using RedApple.DomainNet35.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedApple.DomainNet35.Session
{
    public class SessionResultModel : ResultModel
    {

        public SessionResultModel()
        {

        }
        public SessionResultModel(ResultStatus Status, string Message) : base(Status, Message)
        {



        }
        public SessionResultModel(string ErrorMessage)
        {

            this.ResultStatus = ResultStatus.Error;
            this.Message = ErrorMessage;
        }

        public SessionResultModel(RedGameUser User)
        {
            this.ResultStatus = ResultStatus.Ok;
            this.SessionUser = User;
        }

        public RedGameUser SessionUser { get; set; }





    }


}
