using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cameo;
using static Cameo.BehaviourDefine;

namespace Cameo
{
	public class BehaviourLoggerManager : Singleton<BehaviourLoggerManager>
	{
        [SerializeField]
        private IBehaviourLogger[] loggers;

        [SerializeField]
        private bool isSendLog;

        private void Start()
        {
            Initialize();
        }

        public void Initialize()
        {
            foreach (IBehaviourLogger logger in loggers)
            {
                logger.Initialize();
            }
        }

        public void SendData(BehaviourType eventType)
        {
            if (isSendLog)
            {
                foreach (IBehaviourLogger logger in loggers)
                {
                    logger.SendLog(eventType);
                }
            }
        }
	}
}
