using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cameo
{
    public class AgentDataCollector
    {
        /*
        "actor": {
            "objectType": "Agent",  //固定
            "name": "劉世程",
            "mbox": "mailto:sally@example.com",
            "account": {
                "sysid": "775F0842222584D8E050A8C048170D75",
                "nickname": "cody",
                "birthday": "2000-01-01",
                "sex": "male"
            }
        },
        */

        public void CollectAgentData(List<XapiElement> elements)
        {
            elements.Add(new XapiElement("actor.objectType", "Agent"));

                elements.Add(new XapiElement("actor.name", "(測試用)使用者姓名"));
                elements.Add(new XapiElement("actor.mbox", "email_for_test@example.com"));
                elements.Add(new XapiElement("actor.account.sysid", "test_sysid"));
                elements.Add(new XapiElement("actor.account.nickname", "(測試用)使用者暱稱"));
                elements.Add(new XapiElement("actor.account.birthday", "2000-01-01")); //not get return value
                elements.Add(new XapiElement("actor.account.sex", "male")); //not get return value
        }
    }
}
