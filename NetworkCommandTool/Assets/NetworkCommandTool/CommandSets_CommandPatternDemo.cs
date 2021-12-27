using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloCMD : ICommand
{
    public NetworkMSGInspector network;
    public HelloCMD(NetworkMSGInspector _network)
    {
        network = _network;
    }
    public void ExecuteAction()
    {
        ICommand cmdToSend = new WorldCMD(network);
        network.SendMsg(cmdToSend.ToMsg());
    }

    public bool FromMsg(string msg, out ICommand cmd)
    {
        if (Verification(msg))
        {
            cmd = this;
            return true;
        }
        cmd = new EmptyCMD();
        return false;
    }

    public string ToMsg()
    {
        throw new System.NotImplementedException();
    }

    public bool Verification(string msg)
    {
        if (msg == "Hello") return true;
        else
            return false;
    }
}
public class WorldCMD : ICommand
{
    public NetworkMSGInspector network;
    public WorldCMD(NetworkMSGInspector _network)
    {
        network = _network;
    }
    public void ExecuteAction()
    {
        throw new System.NotImplementedException();
    }


    public bool FromMsg(string msg, out ICommand cmd)
    {
        if (Verification(msg))
        {
            cmd = this;
            return true;
        }
        cmd = new EmptyCMD();
        return false;
    }

    public string ToMsg()
    {
        throw new System.NotImplementedException();
    }

    public bool Verification(string msg)
    {
        if (msg == "World") return true;
        else
            return false;
    }
}
public class EmptyCMD : ICommand
{
    public void ExecuteAction()
    {
        throw new System.NotImplementedException();
    }

    public bool FromMsg(string msg, out ICommand cmd)
    {
        throw new System.NotImplementedException();
    }

    public string ToMsg()
    {
        throw new System.NotImplementedException();
    }

    public bool Verification(string msg)
    {
        throw new System.NotImplementedException();
    }
}

public class CommandSets_CommandPatternDemo : MonoBehaviour, ICommandFactory
{
    public NetworkMSGInspector network;
    private List<ICommand> TargetCommands;
    public void HelloWorldCMDFactoryInit()
    {
        TargetCommands = new List<ICommand>();
        TargetCommands.Add((ICommand)new EmptyCMD());
        TargetCommands.Add((ICommand)new HelloCMD(network));
    }
    public ICommand PharseCommand(string msg)
    {
        ICommand cmd = new EmptyCMD();
        foreach (var iCmd in TargetCommands)
        {
            bool isFound = iCmd.FromMsg(msg, out cmd);
            if (isFound) return cmd;
        }
        Debug.Assert(cmd == new EmptyCMD(), "can' pharse msg to target command :" + msg);
        return cmd;

    }

    public void SendCmd(ICommand cmd)
    {
        string msg = cmd.ToMsg();
        network.SendMsg(msg);
    }
    private void OnRecivedMsg(object sender, RecieveDataEventArgs e)
    {
        if (e.Data.GetType().ToString() == "System.String")
        {
            ICommand cmd = PharseCommand((string)sender);
            cmd.ExecuteAction();
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
