using static Cameo.BehaviourDefine;

namespace Cameo
{
    public class XAPI_illustration_click_item : IBehaviourLogHandler
    {
        public BehaviourLogBase CreateLog()
        {

            BehaviourLogXAPI behaviourLog = new BehaviourLogXAPI();

            //verb
            behaviourLog.AddElement("verb.id", "http://id.tincanapi.com/verb/viewed");
            behaviourLog.AddElement("verb.display.zh-TW", "查看");

            //object
            behaviourLog.AddElement("object.objectType", "Activity");
            behaviourLog.AddElement("object.id", BehaviourType.illustration_click_item.ToString());
            behaviourLog.AddElement("object.definition.category.zh-TW", "互動圖鑑");
            behaviourLog.AddElement("object.definition.name.zh-TW", GetBehaviourName(BehaviourType.illustration_click_item));
            behaviourLog.AddElement("object.definition.description.zh-TW", GetBehaviourDescription(BehaviourType.illustration_click_item));
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