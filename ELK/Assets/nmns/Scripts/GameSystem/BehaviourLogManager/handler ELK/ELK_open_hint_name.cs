using System;
using static Cameo.BehaviourDefine;

namespace Cameo
{
    public class ELK_open_hint_name : IBehaviourLogHandler
    {
        public BehaviourLogBase CreateLog()
        {
            BehaviourLogELK behaviourLog = new BehaviourLogELK();

            behaviourLog.AddElement("strCategory", BehaviourType.open_hint_name.ToString());

            string selectedHintedName = BehaviourDataCenter.GetData(BehaviourDataCenter.DataType.selected_hint_name);
            string time = DateTime.Now.ToString("yyyy/MM/dd hh:mm");
            string actionLog = string.Format(GetBehaviourReferenceFormat(BehaviourType.open_hint_name), selectedHintedName, time);
            behaviourLog.AddElement("strActionLog", actionLog);

            return behaviourLog;
        }
    }
}