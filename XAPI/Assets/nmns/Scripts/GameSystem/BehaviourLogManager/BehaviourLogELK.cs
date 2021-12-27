using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cameo
{
    public class BehaviourLogELK : BehaviourLogBase
    {
        public Dictionary<string, object> Data = new Dictionary<string, object>();

        public void AddElement(string attr, object val)
        {
            Data.Add(attr, val);
        }
    }
}
