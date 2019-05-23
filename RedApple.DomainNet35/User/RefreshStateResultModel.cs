using RedApple.DomainNet35.result;
using RedApple.DomainNet35.status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedApple.DomainNet35.User
{
    public class RefreshStateResultModel:ResultModel
    {
        public UserSessionModel UserSessionModel { get; set; }

        public RefreshStateResultModel(UserSessionModel SessionModel)
        {

            this.ResultStatus = status.ResultStatus.Ok;
            this.UserSessionModel = SessionModel;

        }

        public RefreshStateResultModel(ResultStatus Status, string Message) : base(Status, Message)
        {
        }
    }
}
