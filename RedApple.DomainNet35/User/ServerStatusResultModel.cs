using RedApple.DomainNet35.result;
using RedApple.DomainNet35.status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedApple.DomainNet35.User
{
    public class ServerStatusResultModel : ResultModel
    {
        public readonly ServerStatus serverStatus;

        public ServerStatusResultModel(ResultStatus Status, string Message) : base(Status, Message)
        {

        }

        public ServerStatusResultModel(string ErrorMessage)
        {

            this.ResultStatus = ResultStatus.Error;
            this.Message = ErrorMessage;
        }

        public ServerStatusResultModel(ServerStatus serverStatus)
        {
            this.serverStatus = serverStatus;
            this.ResultStatus = ResultStatus.Ok;
        }

    }
}
