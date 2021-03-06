using System;
using static Cameo.BehaviourDefine;

namespace Cameo
{
    public class ELK_back_to_main_menu_from_illustration : IBehaviourLogHandler
    {
        public BehaviourLogBase CreateLog()
        {
            BehaviourLogELK behaviourLog = new BehaviourLogELK();

            behaviourLog.AddElement("strCategory", BehaviourType.back_to_main_menu_from_illustration.ToString());

            string time = DateTime.Now.ToString("yyyy/MM/dd hh:mm");
            string actionLog = string.Format(GetBehaviourReferenceFormat(BehaviourType.back_to_main_menu_from_illustration), time);
            behaviourLog.AddElement("strActionLog", actionLog);

            return behaviourLog;
        }
    }
}