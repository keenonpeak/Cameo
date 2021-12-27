using static Cameo.BehaviourDefine;

namespace Cameo
{
    public class ELK_photo_save : IBehaviourLogHandler
    {
        public BehaviourLogBase CreateLog()
        {
            BehaviourLogELK behaviourLog = new BehaviourLogELK();

            behaviourLog.AddElement("strCategory", BehaviourType.photo_save.ToString());

            string levelName = BehaviourDataCenter.GetData(BehaviourDataCenter.DataType.level_name);
            string actionLog = string.Format(GetBehaviourReferenceFormat(BehaviourType.photo_save), levelName);
            behaviourLog.AddElement("strActionLog", actionLog);

            return behaviourLog;
        }
    }
}