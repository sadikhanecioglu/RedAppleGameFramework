using RedApple.DomainNet35.status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedApple.DomainNet35.result
{
    public abstract class ResultModel : IDomainNet35
    {

        public ResultModel()
        {

        }

        public ResultModel(ResultStatus Status, string Message)
        {

            this.ResultStatus = Status;
            this.Message = Message;

        }
        public ResultStatus ResultStatus { get; set; }

        public string Message { get; set; }

    }
}
