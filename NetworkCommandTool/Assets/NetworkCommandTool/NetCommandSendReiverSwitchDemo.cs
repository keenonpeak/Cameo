using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetCommandSendReiverSwitchDemo : MonoBehaviour
{
    public enum CommandNames
    {
        Hello,
        World
    }
    public NetworkMSGInspector network;

    private void OnRecivedMsg(object sender, RecieveDataEventArgs e)
    {
        if (e.Data.GetType().ToString() == "System.String")
        {
            PharseCMD((string)sender);
        }
        
    }
    void PharseCMD(string msg)
    {
        CommandNames cmd = (CommandNames)Enum.Parse(typeof(CommandNames), msg);
        switch (cmd)
        {
            case CommandNames.Hello:
                break;
            case CommandNames.World:
                break;

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        network.AddToOnRecived(OnRecivedMsg);
    }



    // Update is called once per frame
    void Update()
    {
        
    }


}
