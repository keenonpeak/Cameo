using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cameo.BehaviourDefine;

namespace Cameo
{
	public abstract class IBehaviourLogger : MonoBehaviour
	{
        [SerializeField]
        protected string classFormat;

        protected Dictionary<string, IBehaviourLogHandler> handlerMapping;

        public void Initialize()
        {
            handlerMapping = new Dictionary<string, IBehaviourLogHandler>();

            foreach (string eventType in Enum.GetNames(typeof(BehaviourType)))
            {
                string loggerHandler = string.Format(classFormat, eventType);

                Debug.LogFormat("Checking log handler {0} is exist", loggerHandler);

                var classType = Type.GetType(string.Format("{0}.{1}", "Cameo", loggerHandler));

                if (classType != null)
                {
                    handlerMapping.Add(eventType, (IBehaviourLogHandler)Activator.CreateInstance(classType));
                    Debug.LogFormat("Register log handler: {0}", loggerHandler);
                }
            }

            customInitialize();
        }

        protected virtual void customInitialize()
        {
            
        }

        public abstract void SendLog(BehaviourDefine.BehaviourType eventType);
	}
}
