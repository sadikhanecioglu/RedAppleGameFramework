using RedApple.DomainNet35.result;
using RedApple.DomainNet35.status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedApple.DomainNet35.Quest
{
    public class QuestResultModel : ResultModel
    {
        public readonly QuestTenant Quest;
        public QuestResultModel()
        {
        }

        public QuestResultModel(ResultStatus Status, string Message) : base(Status, Message)
        {
        }

        public QuestResultModel(QuestTenant Quest)
        {
            this.Quest = Quest;
            this.ResultStatus = ResultStatus.Ok;
        }
    }
}
