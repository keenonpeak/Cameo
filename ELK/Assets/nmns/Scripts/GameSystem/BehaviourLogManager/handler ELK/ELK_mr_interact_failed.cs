using System;
using static Cameo.BehaviourDefine;

namespace Cameo
{
    public class ELK_mr_interact_failed : IBehaviourLogHandler
    {
        public BehaviourLogBase CreateLog()
        {
            BehaviourLogELK behaviourLog = new BehaviourLogELK();

            behaviourLog.AddElement("strCategory", BehaviourType.mr_interact_failed.ToString());

            string selectedMrName = BehaviourDataCenter.GetData(BehaviourDataCenter.DataType.selected_mr_name);
            string selectedMrAnchor = BehaviourDataCenter.GetData(BehaviourDataCenter.DataType.selected_mr_anchor);
            string time = DateTime.Now.ToString("yyyy/MM/dd hh:mm");
            string actionLog = string.Format(GetBehaviourReferenceFormat(BehaviourType.mr_interact_failed), selectedMrName, selectedMrAnchor, time);
            behaviourLog.AddElement("strActionLog", actionLog);

            return behaviourLog;
        }
    }
}