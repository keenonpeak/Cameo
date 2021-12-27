using System;
using static Cameo.BehaviourDefine;

namespace Cameo
{
    public class ELK_play_ar_dinosour : IBehaviourLogHandler
    {
        public BehaviourLogBase CreateLog()
        {
            BehaviourLogELK behaviourLog = new BehaviourLogELK();

            behaviourLog.AddElement("strCategory", BehaviourType.play_ar_dinosour.ToString());

            string selectedIllustrationHall = BehaviourDataCenter.GetData(BehaviourDataCenter.DataType.selected_illustration_hall);
            string selectedArName = BehaviourDataCenter.GetData(BehaviourDataCenter.DataType.selected_ar_name);
            string time = DateTime.Now.ToString("yyyy/MM/dd hh:mm");
            string actionLog = string.Format(GetBehaviourReferenceFormat(BehaviourType.play_ar_dinosour), selectedIllustrationHall, selectedArName, time);
            behaviourLog.AddElement("strActionLog", actionLog);

            return behaviourLog;
        }
    }
}