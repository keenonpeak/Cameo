using System;
using System.Collections;
using System.Collections.Generic;
using Cameo.Elk;
using UnityEngine;

namespace Cameo.Analytic
{
    public class BehaviourLoggerELK : IBehaviourLogger
    {
        protected override void customInitialize()
        {
            CameoElk.Init();
        }

        public override void SendLog(BehaviourDefine.BehaviourType eventType)
        {
            if (handlerMapping.ContainsKey(eventType.ToString()))
            {
                BehaviourLogELK behaviourLogELK = (BehaviourLogELK)handlerMapping[eventType.ToString()].CreateLog();
                addAccountInfo(behaviourLogELK);

                CameoElk.SendData(behaviourLogELK.Data);
            }
            else
            {
                Debug.LogFormat("ELK logger not handle event:{0}", eventType.ToString());
            }
        }

        private void addAccountInfo(BehaviourLogELK behaviourLog)
        {
            string userID = BehaviourDataCenter.GetData(BehaviourDataCenter.DataType.user_account_id);

            behaviourLog.AddElement("strUserID", userID);

            string nmnsID = BehaviourDataCenter.GetData(BehaviourDataCenter.DataType.nmns_member_id);

            behaviourLog.AddElement("strNmnsID", nmnsID);

            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1, 0, 0, 0, 0));
            DateTime nowTime = DateTime.Now;
            string timestamp = ((long)Math.Round((nowTime - startTime).TotalMilliseconds, MidpointRounding.AwayFromZero)).ToString();

            behaviourLog.AddElement("strTimestamp", timestamp);

            string signature = MD5.getStrMd5String(MD5.getStrMd5String(userID + timestamp + "nmns2016@"));

            behaviourLog.AddElement("strSignature", signature);

            behaviourLog.AddElement("GameMode", "single");
        }
    }
}
