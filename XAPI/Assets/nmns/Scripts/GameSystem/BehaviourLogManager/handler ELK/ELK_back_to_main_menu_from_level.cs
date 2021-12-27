using System;
using static Cameo.BehaviourDefine;

namespace Cameo
{
    public class ELK_back_to_main_menu_from_level : IBehaviourLogHandler
    {
        public BehaviourLogBase CreateLog()
        {
            BehaviourLogELK behaviourLog = new BehaviourLogELK();
            string time = DateTime.Now.ToString("yyyy/MM/dd hh:mm");
            string actionLog = string.Format(GetBehaviourReferenceFormat(BehaviourType.back_to_main_menu_from_level), time);
            behaviourLog.AddElement("strCategory", BehaviourType.back_to_main_menu_from_level.ToString());


            behaviourLog.AddElement("strActionLog", actionLog);

            return behaviourLog;
        }
    }
}