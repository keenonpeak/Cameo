using System;
using static Cameo.BehaviourDefine;

namespace Cameo
{
    public class ELK_open_leaderboard : IBehaviourLogHandler
    {
        public BehaviourLogBase CreateLog()
        {
            BehaviourLogELK behaviourLog = new BehaviourLogELK();

            behaviourLog.AddElement("strCategory", BehaviourType.open_leaderboard.ToString());

            string teamName = BehaviourDataCenter.GetData(BehaviourDataCenter.DataType.team_name);
            string teamScore = BehaviourDataCenter.GetData(BehaviourDataCenter.DataType.team_score);
            string time = DateTime.Now.ToString("yyyy/MM/dd hh:mm");
            string actionLog = string.Format(GetBehaviourReferenceFormat(BehaviourType.open_leaderboard), teamName, teamScore, time);
            behaviourLog.AddElement("strActionLog", actionLog);

            return behaviourLog;
        }
    }
}