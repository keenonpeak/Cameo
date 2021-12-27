using System;
using static Cameo.BehaviourDefine;

namespace Cameo
{
    public class ELK_mr_end : IBehaviourLogHandler
    {
        public BehaviourLogBase CreateLog()
        {
            BehaviourLogELK behaviourLog = new BehaviourLogELK();

            behaviourLog.AddElement("strCategory", BehaviourType.mr_end.ToString());

            string selectedMrName = BehaviourDataCenter.GetData(BehaviourDataCenter.DataType.selected_mr_name);
            string time = DateTime.Now.ToString("yyyy/MM/dd hh:mm");
            string actionLog = string.Format(GetBehaviourReferenceFormat(BehaviourType.mr_end), selectedMrName, time);
            behaviourLog.AddElement("strActionLog", actionLog);

            return behaviourLog;
        }
    }
}