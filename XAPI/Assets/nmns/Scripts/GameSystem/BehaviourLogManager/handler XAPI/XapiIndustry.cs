using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NestData = System.Collections.Generic.Dictionary<string, object>;

namespace Cameo
{
    /// <summary>
    /// 把 XAPI 的內容從巢狀轉換成 (Key,Value) 的 pair
    /// ex: (result.score.scaled, 85)
    /// </summary>

    public class XapiElement
    {
        public string Attribute;
        public object Value;

        public XapiElement(string attr, object val)
        {
            Attribute = attr;
            Value = val;
        }
    }

    /// <summary>
    /// 輸入 (Key,Value) 的 pair 的串列，
    /// 組合成 XAPI 上傳的內容
    /// </summary>

    public static class XapiIndustry
    {
        public static string CreateXapiContent(List<XapiElement> elements)
        {
            NestData root = new NestData();

            foreach (XapiElement element in elements)
            {
                string[] attributes = element.Attribute.Split('.');
                NestData node = root;

                for (int i = 0; i < attributes.Length; ++i)
                {
                    if (i < attributes.Length - 1)
                    {
                        if (!node.ContainsKey(attributes[i]))
                        {
                            node.Add(attributes[i], new NestData());
                        }
                        node = (NestData)node[attributes[i]];
                    }
                    else
                    {
                        node.Add(attributes[i], element.Value);
                    }
                }
            }

            string jsonStr = LitJson.JsonMapper.ToJson(root);

            return jsonStr;
        }

        public static void GetTestContent()
        {
            List<XapiElement> elements = new List<XapiElement>();
            elements.Add(new XapiElement("actor.objectType", "Agent"));
            elements.Add(new XapiElement("actor.name", "Cody Lioy"));
            elements.Add(new XapiElement("actor.mbox", "cody@brightideas.com.tw"));
            elements.Add(new XapiElement("verb.id", "https://w3id.org/xapi/adb/verbs/selected"));
            elements.Add(new XapiElement("verb.display.zh-TW", "活動 (Activity)"));
            elements.Add(new XapiElement("object.objectType", "Activity"));
            elements.Add(new XapiElement("object.definition", null));
            Debug.Log(CreateXapiContent(elements));
        } 
    }
}
