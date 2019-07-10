using RedApple.DomainNet35.result;
using RedApple.DomainNet35.status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedApple.DomainNet35.Quest
{
    public class PromotionResultModel : ResultModel
    {
        public readonly Promotion promotion;

        public PromotionResultModel()
        {
        }

        public PromotionResultModel(ResultStatus Status, string Message) : base(Status, Message)
        {
        }

        public PromotionResultModel(string ErrorMessage)
        {

            this.ResultStatus = ResultStatus.Error;
            this.Message = ErrorMessage;
        }

        public PromotionResultModel(Promotion promotion)
        {
            this.promotion = promotion;
            this.ResultStatus = ResultStatus.Ok;
        }
    }
}
