using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using BehaviourType = Cameo.BehaviourDefine.BehaviourType;

namespace Cameo
{
    public class BehaviourLoggerXAPI : IBehaviourLogger
    {
        [SerializeField]
        private string url;

        [SerializeField]
        private string serviceID = "7901fb6b-f0e8-44a1-b2b2-2abd9793224c"; //單人版

        [SerializeField]
        private string serviceName = "探索科博尋寶趣";

        [SerializeField]
        private string serviceArea = "國立自然科學博物館";

        private AgentDataCollector collector;

        protected override void customInitialize()
        {
            var classType = Type.GetType("Cameo.AgentDataCollector");

            if (classType != null)
            {
                collector = (AgentDataCollector)Activator.CreateInstance(classType);
            }
            else
            {
                Debug.LogError("Instanciate agent collector failed!");
            }
        }

        public override void SendLog(BehaviourDefine.BehaviourType eventType)
        {
            if(handlerMapping.ContainsKey(eventType.ToString()))
            {
                BehaviourLogXAPI behaviourLog = (BehaviourLogXAPI)handlerMapping[eventType.ToString()].CreateLog();
                addAgent(behaviourLog);
                addTimeStamp(behaviourLog);
                addGeneralContext(behaviourLog);
                string logContent = XapiIndustry.CreateXapiContent(behaviourLog.Elements);
                Debug.Log(logContent);

                StartCoroutine(sendCoroutine(logContent));
            }
            else
            {
                Debug.LogFormat("XAPI logger not handle event:{0}", eventType.ToString());
            }
        }

        private IEnumerator sendCoroutine(string logContent)
        {
            var request = new UnityWebRequest(url, "POST");
            request.SetRequestHeader("Content-Type", "application/json");
            byte[] bodyRaw = Encoding.UTF8.GetBytes(logContent);
            request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            Debug.Log(request.url);

            yield return request.SendWebRequest();
            Debug.Log("Upload XAPI Status Code: " + request.downloadHandler.text);
        }

        private void addAgent(BehaviourLogXAPI behaviourLog)
        {
            if(collector != null)
            {
                collector.CollectAgentData(behaviourLog.Elements);
            }
        }

        private void addTimeStamp(BehaviourLogXAPI behaviourLog)
        {
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1, 0, 0, 0, 0));
            DateTime nowTime = DateTime.Now;
            long unixTime = (long)Math.Round((nowTime - startTime).TotalMilliseconds, MidpointRounding.AwayFromZero);
            behaviourLog.AddElement("timestamp", unixTime.ToString());
        }

        private void addGeneralContext(BehaviourLogXAPI behaviourLog)
        {
            behaviourLog.AddElement("context.service.serviceId", serviceID);
            behaviourLog.AddElement("context.service.serviceTitle", serviceName);
            behaviourLog.AddElement("context.service.serviceArea", serviceName);
#if(UNITY_IPHONE)
            behaviourLog.AddElement("context.platform", "iOS");
#elif (UNITY_ANDROID)
            behaviourLog.AddElement("context.platform", "Android");
#endif
            behaviourLog.AddElement("context.language", "zh-TW");
            behaviourLog.AddElement("context.launchmode", "參觀中");
        }
    }
}