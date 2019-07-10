using RedApple.DomainNet35.Dto;

namespace RedApple.DomainNet35.Quest
{
    public class PromotionDto : IDtoNet35
    {
        public PromotionDto()
        {

        }

        public PromotionDto(string promotionCode)
        {
            this.PromotionCode = promotionCode;
        }

        public string PromotionCode { get; set; }
    }
}
