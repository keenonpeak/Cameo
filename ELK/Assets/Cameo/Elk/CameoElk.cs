////////////////////////////////////////////////////////////////////////////////
//  
// @module Cameo Elk Plugin
// @author bigcookie 
// @support bigcookie.lee@cameo.tw
//
////////////////////////////////////////////////////////////////////////////////

using System.Collections.Generic;
using UnityEngine;
using CI.HttpClient;
using System;
using LitJson;

namespace Cameo.Elk {

    public class CameoElk:MonoBehaviour {

        private static CameoElk Instance = null;
        private static string url = "";

    	private void Awake()
    	{
            if (Instance != null)
            {
                DestroyImmediate(gameObject);
                return;
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }

            if (CameoElk_Settings.Instance.IsUseHttps)
            {
                url = "https://";
            }
            else
            {
                url = "http://";
            }

            url = url + CameoElk_Settings.Instance.ElkServerIp;

            if (CameoElk_Settings.Instance.Category != "") {
                url = url + "/" + CameoElk_Settings.Instance.Category + "/";
            }

            Debug.Log("[CameoElk] Awake / url: " + url);

            name = "Cameo Elk";
    	}


        public static void Init()
        {
            Instance = FindObjectOfType<CameoElk>();
            if (Instance == null)
            {
                var objectName = "Cameo Elk";
                GameObject an = GameObject.Find(objectName);
                if (an == null)
                {
                    an = new GameObject(objectName);
                }

                an.AddComponent<CameoElk>();
            }
        }
       
        public static void SendData(Dictionary<string, object> data) {
            //data.Add("timestamp", System.DateTime.Now.ToString("o"));
            Debug.Log("[CameoElk] SendData / data: " + JsonMapper.ToJson(data));

            HttpClient httpClient = new HttpClient();
            StringContent stringContent = new StringContent(JsonMapper.ToJson(data), System.Text.Encoding.UTF8, "application/json");

            Debug.Log("[CameoElk] SendData / url: " + url);

            httpClient.Post(new Uri(url), stringContent, HttpCompletionOption.AllResponseContent, (r) =>
            {
                Debug.Log("[CameoElk] SendData / return data: " + r.StatusCode);
            });
        }
    }
}
