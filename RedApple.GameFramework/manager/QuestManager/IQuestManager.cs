using RedApple.DomainNet35.Quest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedApple.GameFramework.manager.QuestManager
{
    public partial interface IQuestManager
    {
        void GetNewQuest(Action<QuestResultModel> onComplate);
    }
}
