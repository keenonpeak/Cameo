using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Cameo.Face;
public class FaceDataReciver : MonoBehaviour
{
    public UdpServerClient UDP;

    //  public ARBlendShapeCharacter FaceController;
    int fpsCounter = 0;
    float preTime = 0;
    public float recivedFPS;
    private float preTimeStamp = 0;
    private void ListenToFaceData(object data)
    {

        if (data.GetType().ToString() == "System.String")
        {
            string namelist = (string)data;
            //foreach (var obj in namelist) Debug.Log(obj);
            Debug.Log("Get from server : " + namelist);
            //   FaceController.blendShapeKeys = namelist;
        }
        else if (data.GetType().ToString() == "System.Single[]")
        {

            float[] keyValues = (float[])data;
            float curTimeStamp = keyValues[0];
            float[] realKeyValue = new float[keyValues.Length - 1];
            for (int i = 0; i < realKeyValue.Length; i++)
            {
                realKeyValue[i] = keyValues[i + 1];
            }
            if (curTimeStamp > preTimeStamp || Mathf.Abs(curTimeStamp - preTimeStamp) > 1000)
            {
                //   FaceController.ManulUpdateShapeKey(realKeyValue);
                preTimeStamp = curTimeStamp;
            }

            fpsCounter++;
        }
        else
        {
            print(data.GetType());
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        if (UDP != null)
        {
            UDP.hoster.RecievedData += (o, e) =>
            {
                if (e != null)
                {
                    ListenToFaceData(e.Data);
                }
                else
                {
                    print("no e");
                }
            };

        }

        // Update is called once per frame
        void Update()
        {
            if (fpsCounter >= 50)
            {
                float CurrentTIme = Time.time;
                float duration = CurrentTIme - preTime;
                recivedFPS = fpsCounter / duration;
                preTime = CurrentTIme;
                //fpsCounter = 0;
            }
        }
    }
}
