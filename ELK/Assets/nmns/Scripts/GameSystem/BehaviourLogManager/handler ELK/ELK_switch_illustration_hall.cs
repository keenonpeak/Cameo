using System;
using static Cameo.BehaviourDefine;

namespace Cameo
{
    public class ELK_switch_illustration_hall : IBehaviourLogHandler
    {
        public BehaviourLogBase CreateLog()
        {
            BehaviourLogELK behaviourLog = new BehaviourLogELK();

            behaviourLog.AddElement("strCategory", BehaviourType.switch_illustration_hall.ToString());

            string selectedIllustrationHall = BehaviourDataCenter.GetData(BehaviourDataCenter.DataType.selected_illustration_hall);
            string time = DateTime.Now.ToString("yyyy/MM/dd hh:mm");
            string actionLog = string.Format(GetBehaviourReferenceFormat(BehaviourType.switch_illustration_hall), selectedIllustrationHall, time);
            behaviourLog.AddElement("strActionLog", actionLog);

            return behaviourLog;
        }
    }
}