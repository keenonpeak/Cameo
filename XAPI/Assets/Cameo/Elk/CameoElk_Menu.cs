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
    
    public class CameoElk_Menu : EditorWindow
    {

        #if UNITY_EDITOR
        [MenuItem("Window/Cameo/Elk/Edit Settings", false, 200)]
        public static void Edit()
        {
            Selection.activeObject = CameoElk_Settings.Instance;
        }
        #endif
        
    }

}
#endif
