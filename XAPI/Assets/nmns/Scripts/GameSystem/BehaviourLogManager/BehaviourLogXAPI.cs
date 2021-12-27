using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cameo
{
    public class BehaviourLogXAPI : BehaviourLogBase
    {
        public List<XapiElement> Elements = new List<XapiElement>();

        public void AddElement(string attr, object val)
        {
            Elements.Add(new XapiElement(attr, val));
        }
    }

}
