using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedApple.DomainNet35.Quest
{
    public class QuestTenant
    {
        public string Quest { get; set; }
        public int AnswerCount { get; set; }
        public string KeyBoard { get; set; }
        public string TimeStart { get; set; }
        public string Hint { get; set; }
    }
}
