using System;
using static Cameo.BehaviourDefine;

namespace Cameo
{
    public class ELK_take_photo_in_ar : IBehaviourLogHandler
    {
        public BehaviourLogBase CreateLog()
        {
            BehaviourLogELK behaviourLog = new BehaviourLogELK();

            behaviourLog.AddElement("strCategory", BehaviourType.take_photo_in_ar.ToString());

            string selectedIllustrationHall = BehaviourDataCenter.GetData(BehaviourDataCenter.DataType.selected_illustration_hall);
            string selectedArName = BehaviourDataCenter.GetData(BehaviourDataCenter.DataType.selected_ar_name);
            string time = DateTime.Now.ToString("yyyy/MM/dd hh:mm");
            string actionLog = string.Format(GetBehaviourReferenceFormat(BehaviourType.take_photo_in_ar), selectedIllustrationHall, selectedArName, time);
            behaviourLog.AddElement("strActionLog", actionLog);

            return behaviourLog;
        }
    }
}