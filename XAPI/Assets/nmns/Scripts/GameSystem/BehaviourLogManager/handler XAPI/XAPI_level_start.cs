﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cameo.BehaviourDefine;

namespace Cameo
{
    public class XAPI_select_level : IBehaviourLogHandler
    {
        public BehaviourLogBase CreateLog()
        {
            BehaviourLogXAPI behaviourLog = new BehaviourLogXAPI();

            //verb
            behaviourLog.AddElement("verb.id", "http://id.tincanapi.com/verb/viewed");
            behaviourLog.AddElement("verb.display.zh-TW", "互動");

            //object
            behaviourLog.AddElement("object.objectType", "Activity");
            behaviourLog.AddElement("object.id", BehaviourType.level_start.ToString());
            string levelName = BehaviourDataCenter.GetData(BehaviourDataCenter.DataType.level_name);
            behaviourLog.AddElement("object.definition.category.zh-TW", levelName);
            behaviourLog.AddElement("object.definition.name.zh-TW", "");
            behaviourLog.AddElement("object.definition.description.zh-TW", GetBehaviourDescription(BehaviourType.level_start));
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