////////////////////////////////////////////////////////////////////////////////
//  
// @module Cameo Elk Plugin
// @author bigcookie 
// @support bigcookie.lee@cameo.tw
//
////////////////////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Cameo.Elk {
    
    #if UNITY_EDITOR
    [InitializeOnLoad]
    #endif
    public class CameoElk_Settings : ScriptableObject {
        
        private const string STR_SETTING_FILEPATH = "Cameo/Elk";
        private const string STR_RESOURCE_PATH = "CameoElk_Settings";
        private const string STR_EXTENSION = ".asset";

        public bool IsUseHttps = false;
        public string ElkServerIp = string.Empty;
        public string Category = "cameo";

        private static CameoElk_Settings instance = null;

        public static CameoElk_Settings Instance
        {

            get
            {

                if (instance == null)
                {
                    instance = Resources.Load(STR_RESOURCE_PATH) as CameoElk_Settings;

                    if (instance == null)
                    {
                        // If not found, autocreate the asset object.
                        instance = CreateInstance<CameoElk_Settings>();
                        #if UNITY_EDITOR
                        string strFilePath = Application.dataPath + "/" + STR_SETTING_FILEPATH + "/Resources/" + STR_RESOURCE_PATH + STR_EXTENSION;
                        if (!File.Exists(strFilePath))
                        {
                            string folder = System.IO.Path.GetDirectoryName(strFilePath);
                            if (Directory.Exists(folder) == false)
                            {
                                Directory.CreateDirectory(folder);
                            }
                        }

                        AssetDatabase.CreateAsset(instance, "Assets/" + STR_SETTING_FILEPATH + "/Resources/" + STR_RESOURCE_PATH + STR_EXTENSION);
                        #endif
                    }
                }
                return instance;
            }
        }
    }

}
