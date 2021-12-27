////////////////////////////////////////////////////////////////////////////////
//  
// @module Cameo Elk Plugin
// @author bigcookie 
// @support bigcookie.lee@cameo.tw
//
////////////////////////////////////////////////////////////////////////////////

#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Cameo.Elk {

    [CustomEditor(typeof(CameoElk_Settings))]
    public class CameoElk_SettingsEditor : UnityEditor.Editor
    {

        public override void OnInspectorGUI()
        {
            DrawAnalyticsSettings();
        }

        public static void DrawAnalyticsSettings()
        {
            GUI.changed = false;

            ElkServerSettings();
            EditorGUILayout.Space();
            CategorySettings();
            EditorGUILayout.Space();

            if (GUI.changed)
            {
                DirtyEditor();
            }
        }

        private static void ElkServerSettings()
        {
            EditorGUILayout.HelpBox("ELK Server Settings", MessageType.None);
            EditorGUI.BeginChangeCheck();
            CameoElk_Settings.Instance.IsUseHttps = EditorGUILayout.Toggle(new GUIContent("Use Https"), CameoElk_Settings.Instance.IsUseHttps);
            CameoElk_Settings.Instance.ElkServerIp = EditorGUILayout.TextField(new GUIContent("ELK Server Ip"), CameoElk_Settings.Instance.ElkServerIp);
            
            //if (EditorGUI.EndChangeCheck())
            //{
            //    UpdateLibsInstalation();
            //}
        }

        private static void CategorySettings()
        {
            EditorGUILayout.HelpBox("Data Category Settings", MessageType.None);
            EditorGUI.BeginChangeCheck();
            CameoElk_Settings.Instance.Category = EditorGUILayout.TextField(new GUIContent("Data Category"), CameoElk_Settings.Instance.Category);
        }

        private static void DirtyEditor()
        {
            EditorUtility.SetDirty(CameoElk_Settings.Instance);
        }
    }

}
#endif
