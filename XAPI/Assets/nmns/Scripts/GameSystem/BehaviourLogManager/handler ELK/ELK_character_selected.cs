using System;
using static Cameo.BehaviourDefine;

namespace Cameo
{
    public class ELK_character_selected : IBehaviourLogHandler
    {
        public BehaviourLogBase CreateLog()
        {
            BehaviourLogELK behaviourLog = new BehaviourLogELK();

            behaviourLog.AddElement("strCategory", BehaviourType.character_selected.ToString());

            string cutomUserName = BehaviourDataCenter.GetData(BehaviourDataCenter.DataType.custom_user_name);
            string teamName = BehaviourDataCenter.GetData(BehaviourDataCenter.DataType.team_name);
            string customCharacterName = BehaviourDataCenter.GetData(BehaviourDataCenter.DataType.custom_character_name);
            string time = DateTime.Now.ToString("yyyy/MM/dd hh:mm");
            string actionLog = string.Format(GetBehaviourReferenceFormat(BehaviourType.character_selected), cutomUserName, teamName, customCharacterName, time);
            behaviourLog.AddElement("strActionLog", actionLog);

            return behaviourLog;
        }
    }
}