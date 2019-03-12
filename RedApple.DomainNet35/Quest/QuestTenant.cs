using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedApple.DomainNet35.Quest
{
    public class QuestTenant
    {

        public long Id { get; set; }
        public string Quest { get; set; }
        public int QuestType { get; set; }
        public string Answer { get; set; }
        public int AnswerType { get; set; }
        public int AnswerCount { get; set; }

    }
}
