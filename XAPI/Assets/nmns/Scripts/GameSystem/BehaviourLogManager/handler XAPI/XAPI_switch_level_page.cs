using static Cameo.BehaviourDefine;

namespace Cameo
{
    public class XAPI_switch_level_page : IBehaviourLogHandler
    {
        public BehaviourLogBase CreateLog()
        {

            BehaviourLogXAPI behaviourLog = new BehaviourLogXAPI();

            //verb
            behaviourLog.AddElement("verb.id", "http://adlnet.gov/expapi/verbs/interacted");
            behaviourLog.AddElement("verb.display.zh-TW", "互動");

            //object
            behaviourLog.AddElement("object.objectType", "Activity");
            behaviourLog.AddElement("object.id", BehaviourType.switch_level_page.ToString());
            behaviourLog.AddElement("object.definition.category.zh-TW", "遊戲主題");
            behaviourLog.AddElement("object.definition.name.zh-TW", GetBehaviourName(BehaviourType.switch_level_page));
            behaviourLog.AddElement("object.definition.description.zh-TW", GetBehaviourDescription(BehaviourType.switch_level_page));
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