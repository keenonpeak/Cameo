using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cameo.BehaviourDefine;

namespace Cameo
{
    public class ELK_user_login : IBehaviourLogHandler
    {
        public BehaviourLogBase CreateLog()
        {
            BehaviourLogELK behaviourLog = new BehaviourLogELK();

            string actionLog = string.Format(GetBehaviourReferenceFormat(BehaviourType.user_login),
                BehaviourDataCenter.GetData(BehaviourDataCenter.DataType.nmns_member_id),
                BehaviourDataCenter.GetData(BehaviourDataCenter.DataType.user_account_id),
                DateTime.Now.ToString("yyyy/MM/dd hh:mm"));

            behaviourLog.AddElement("strCategory", BehaviourType.user_login.ToString());
            behaviourLog.AddElement("strActionLog", actionLog);

            return behaviourLog;
        }
    }
}
