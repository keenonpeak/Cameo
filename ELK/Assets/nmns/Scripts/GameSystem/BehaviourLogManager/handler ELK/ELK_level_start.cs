using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cameo.BehaviourDefine;

namespace Cameo
{
    public class ELK_level_start : IBehaviourLogHandler
    {
        public BehaviourLogBase CreateLog()
        {
            BehaviourLogELK behaviourLog = new BehaviourLogELK();
            string levelName = BehaviourDataCenter.GetData(BehaviourDataCenter.DataType.level_name);
            string time = DateTime.Now.ToString("yyyy/MM/dd hh:mm");
            string actionLog = string.Format(GetBehaviourReferenceFormat(BehaviourType.level_start), levelName, time);

            behaviourLog.AddElement("strCategory", BehaviourType.level_start.ToString());
            behaviourLog.AddElement("strActionLog", actionLog);

            return behaviourLog;
        }
    }
}