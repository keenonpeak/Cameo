using UnityEngine;
using UnityEngine.UI;

public class MRAppLauncher : MonoBehaviour
{
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        BeCallWithParam();
    }

    [System.Serializable]
    public class MRParamter
    {

        public string AppPackageName;

        public string MRID;

        public string MRName;

        public string EnddingMessage;

        public string ReturnValue;

    }

    public Text ShowParam;
    private MRParamter param;
    public static MRAppLauncher instance;
    public string ParamKey = "MRParam";

    void BeCallWithParam()
    {
        AndroidJavaClass UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject currentActivity = UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        if (currentActivity != null)
        {
            AndroidJavaObject intent = currentActivity.Call<AndroidJavaObject>("getIntent");
            bool hasExtra = intent.Call<bool>("hasExtra", ParamKey);    //function/key
            ShowParam.text = "have currentActivity";

            if (hasExtra)
            {
                AndroidJavaObject extras = intent.Call<AndroidJavaObject>("getExtras");
                ShowParam.text = "extras";
                param = JsonUtility.FromJson<MRParamter>(extras.Call<string>("getString", ParamKey));
                // todo : show all param on screen
                ShowParam.text = param.AppPackageName+"\n"+param.MRID+"\n"+param.MRName+"\n"+param.EnddingMessage+"\n"+param.ReturnValue;
            }
        }
    }
    //[BacktoTester]
    public void OnClick_BackAppWithParam()
    {
        ReturnWithParam();
    }

    public void BackAppWithParam(string packageName, string key, string data)
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

    public static void ReturnWithParam()
    {
        instance.BackAppWithParam(instance.param.AppPackageName, instance.ParamKey, instance.param.ReturnValue);
    }
}