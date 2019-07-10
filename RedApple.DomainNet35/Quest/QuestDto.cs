using RedApple.DomainNet35.Dto;

namespace RedApple.DomainNet35.Quest
{
    public class QuestDto : IDtoNet35
    {
        public QuestDto()
        {

        }

        public QuestDto(string Answer)
        {
            this.Answer = Answer;
        }

        public string Answer { get; set; }
    }
}
