using System;
using static Cameo.BehaviourDefine;

namespace Cameo
{
    public class ELK_quest_correct : IBehaviourLogHandler
    {
        public BehaviourLogBase CreateLog()
        {
            BehaviourLogELK behaviourLog = new BehaviourLogELK();

            behaviourLog.AddElement("strCategory", BehaviourType.quest_correct.ToString());

            string levelName = BehaviourDataCenter.GetData(BehaviourDataCenter.DataType.level_name);
            string questName = BehaviourDataCenter.GetData(BehaviourDataCenter.DataType.quest_name);
            string answerContent = BehaviourDataCenter.GetData(BehaviourDataCenter.DataType.answer_content);
            string time = DateTime.Now.ToString("yyyy/MM/dd hh:mm");
            string actionLog = string.Format(GetBehaviourReferenceFormat(BehaviourType.quest_correct), levelName, questName, answerContent, time);
            behaviourLog.AddElement("strActionLog", actionLog);

            return behaviourLog;
        }
    }
}