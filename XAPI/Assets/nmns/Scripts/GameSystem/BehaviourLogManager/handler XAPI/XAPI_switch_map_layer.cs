using static Cameo.BehaviourDefine;

namespace Cameo
{
    public class XAPI_switch_map_layer : IBehaviourLogHandler
    {
        public BehaviourLogBase CreateLog()
        {

            BehaviourLogXAPI behaviourLog = new BehaviourLogXAPI();

            //verb
            behaviourLog.AddElement("verb.id", "http://id.tincanapi.com/verb/viewed");
            behaviourLog.AddElement("verb.display.zh-TW", "查看");

            //object
            behaviourLog.AddElement("object.objectType", "Activity");
            behaviourLog.AddElement("object.id", BehaviourType.switch_map_layer.ToString());
            string levelName = BehaviourDataCenter.GetData(BehaviourDataCenter.DataType.level_name);
            behaviourLog.AddElement("object.definition.category.zh-TW", levelName);
            behaviourLog.AddElement("object.definition.name.zh-TW", GetBehaviourName(BehaviourType.switch_map_layer));
            behaviourLog.AddElement("object.definition.description.zh-TW", GetBehaviourDescription(BehaviourType.switch_map_layer));
            behaviourLog.AddElement("object.definition.type", "http://adlnet.gov/expapi/activities/interaction");

            //result
            behaviourLog.AddElement("result.completion", false);
            behaviourLog.AddElement("result.success", false);
            behaviourLog.AddElement("result.response", "");
            behaviourLog.AddElement("result.score.raw", 0);
            behaviourLog.AddElement("result.score.scaled", 0);

            //context
            //only use general context

            return behaviourLog;
        }
    }
}