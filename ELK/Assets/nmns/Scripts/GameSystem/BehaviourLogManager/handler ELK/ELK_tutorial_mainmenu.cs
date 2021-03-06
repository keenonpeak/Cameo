using System;
using static Cameo.BehaviourDefine;

namespace Cameo
{
    public class ELK_tutorial_mainmenu : IBehaviourLogHandler
    {
        public BehaviourLogBase CreateLog()
        {
            BehaviourLogELK behaviourLog = new BehaviourLogELK();

            behaviourLog.AddElement("strCategory", BehaviourType.tutorial_mainmenu.ToString());

            string selectTutorialImageId = BehaviourDataCenter.GetData(BehaviourDataCenter.DataType.select_tutorial_image_id);
            string time = DateTime.Now.ToString("yyyy/MM/dd hh:mm");
            string actionLog = string.Format(GetBehaviourReferenceFormat(BehaviourType.tutorial_mainmenu), selectTutorialImageId, time);
            behaviourLog.AddElement("strActionLog", actionLog);

            return behaviourLog;
        }
    }
}