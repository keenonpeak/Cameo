using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cameo.BehaviourDefine;

namespace Cameo
{
    public class XAPI_user_login : IBehaviourLogHandler
    {
        public BehaviourLogBase CreateLog()
        {
           
            BehaviourLogXAPI behaviourLog = new BehaviourLogXAPI();

            //verb
            behaviourLog.AddElement("verb.id", "http://id.tincanapi.com/verb/viewed");
            behaviourLog.AddElement("verb.display.zh-TW", "查看");

            //object
            behaviourLog.AddElement("object.objectType", "Activity");
            behaviourLog.AddElement("object.id", BehaviourType.user_login.ToString());
            string userAccountId = BehaviourDataCenter.GetData(BehaviourDataCenter.DataType.user_account_id);
            string nmnsMemberId = BehaviourDataCenter.GetData(BehaviourDataCenter.DataType.nmns_member_id);
            behaviourLog.AddElement("object.definition.category.zh-TW", userAccountId);
            behaviourLog.AddElement("object.definition.name.zh-TW", GetBehaviourName(BehaviourType.user_login));
            behaviourLog.AddElement("object.definition.description.zh-TW", GetBehaviourDescription(BehaviourType.user_login));
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