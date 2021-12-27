using System;
using static Cameo.BehaviourDefine;

namespace Cameo
{
    public class ELK_team_member_added : IBehaviourLogHandler
    {
        public BehaviourLogBase CreateLog()
        {
            BehaviourLogELK behaviourLog = new BehaviourLogELK();

            behaviourLog.AddElement("strCategory", BehaviourType.team_member_added.ToString());

            string cutomUserName = BehaviourDataCenter.GetData(BehaviourDataCenter.DataType.custom_user_name);
            string teamName = BehaviourDataCenter.GetData(BehaviourDataCenter.DataType.team_name);
            string time = DateTime.Now.ToString("yyyy/MM/dd hh:mm");
            string actionLog = string.Format(GetBehaviourReferenceFormat(BehaviourType.team_member_added), cutomUserName, teamName, time);
            behaviourLog.AddElement("strActionLog", actionLog);

            return behaviourLog;
        }
    }
}