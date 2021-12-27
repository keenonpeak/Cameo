using UnityEngine;

[System.Serializable]
public class CallingMRAppLauncher : MonoBehaviour
{
    [System.Serializable]
    public class MRParamter
    {

        public string AppPackageName;

        public string MRID;

        public string MRName;

        public string EnddingMessage;

        public string ReturnValue;

    }

    public void OnClick_CallAppWithParam()
    {
        MRParamter sendParam = new MRParamter();
        sendParam.AppPackageName = "com.Tester.CallingAppTester";
        sendParam.MRID = "testID";
        sendParam.MRName = "testItem";
        sendParam.EnddingMessage = "testEnddingMessage";
        sendParam.ReturnValue = "return test";
        string sendParamToString = JsonUtility.ToJson(sendParam);
        Debug.Log(sendParamToString);
        CallAppWithParam("com.Cameo.MRAppLauncher", "MRParam", sendParamToString);
    }
    public void CallAppWithParam(string packageName, string key, string data)
    {
        AndroidJavaClass up = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject ca = up.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaObject packageManager = ca.Call<AndroidJavaObject>("getPackageManager");
        AndroidJavaObject launchIntent = null;
        try
        {
            launchIntent = packageManager.Call<AndroidJavaObject>("getLaunchIntentForPackage", packageName);
            launchIntent.Call<AndroidJavaObject>("putExtra", key, data);
            ca.Call("startActivity", launchIntent);
        }
        catch (System.Exception e)
        {
            Debug.Log("app not found");
        }
    }
}
