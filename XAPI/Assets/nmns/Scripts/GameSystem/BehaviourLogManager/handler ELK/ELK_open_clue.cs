using System;
using static Cameo.BehaviourDefine;

namespace Cameo
{
    public class ELK_open_clue : IBehaviourLogHandler
    {
        public BehaviourLogBase CreateLog()
        {
            BehaviourLogELK behaviourLog = new BehaviourLogELK();

            behaviourLog.AddElement("strCategory", BehaviourType.open_clue.ToString());

            string selectedClueName = BehaviourDataCenter.GetData(BehaviourDataCenter.DataType.selected_clue_name);
            string time = DateTime.Now.ToString("yyyy/MM/dd hh:mm");
            string actionLog = string.Format(GetBehaviourReferenceFormat(BehaviourType.open_clue), selectedClueName, time);
            behaviourLog.AddElement("strActionLog", actionLog);

            return behaviourLog;
        }
    }
}