using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedApple.DomainNet35.Dto.request
{
    public class GeneralResultModel
    {
        public GeneralResultType ResultType { get; set; }
        public string Message { get; set; }

        public GeneralResultModel()
        {

        }

        public GeneralResultModel(GeneralResultType ResultType, string Message)
        {
            this.ResultType = ResultType;
            this.Message = Message;
        }

    }


}
