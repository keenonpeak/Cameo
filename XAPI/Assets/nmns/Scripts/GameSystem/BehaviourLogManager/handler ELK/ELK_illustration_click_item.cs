using System;
using static Cameo.BehaviourDefine;

namespace Cameo
{
    public class ELK_illustration_click_item : IBehaviourLogHandler
    {
        public BehaviourLogBase CreateLog()
        {
            BehaviourLogELK behaviourLog = new BehaviourLogELK();

            behaviourLog.AddElement("strCategory", BehaviourType.illustration_click_item.ToString());

            string selectedIllustrationName = BehaviourDataCenter.GetData(BehaviourDataCenter.DataType.selected_illustration_name);
            string time = DateTime.Now.ToString("yyyy/MM/dd hh:mm");
            string actionLog = string.Format(GetBehaviourReferenceFormat(BehaviourType.illustration_click_item), selectedIllustrationName, time);
            behaviourLog.AddElement("strActionLog", actionLog);

            return behaviourLog;
        }
    }
}