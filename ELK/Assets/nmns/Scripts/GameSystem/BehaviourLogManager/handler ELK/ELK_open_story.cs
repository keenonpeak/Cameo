using System;
using static Cameo.BehaviourDefine;

namespace Cameo
{
    public class ELK_open_story : IBehaviourLogHandler
	{
		public BehaviourLogBase CreateLog()
		{
			BehaviourLogELK behaviourLog = new BehaviourLogELK();

			behaviourLog.AddElement("strCategory", BehaviourType.open_story.ToString());

            string levelName = BehaviourDataCenter.GetData(BehaviourDataCenter.DataType.level_name);
            string missionName = BehaviourDataCenter.GetData(BehaviourDataCenter.DataType.mission_name);
            string time = DateTime.Now.ToString("yyyy/MM/dd hh:mm");
			string actionLog = string.Format(GetBehaviourReferenceFormat(BehaviourType.open_story), levelName, missionName, time);
			behaviourLog.AddElement("strActionLog", actionLog);

			return behaviourLog;
		}
	}
}