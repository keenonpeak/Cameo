using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region NetworkRelative
[System.Serializable]
public class ConnectionInfo
{
    public string IP;
    public string Port;
    public string ServiceName;
    public string ExtendParametersJSON;
    public override string ToString()
    {
        return JsonUtility.ToJson(this);
    }
    public ConnectionInfo FromString(string msg)
    {
        return JsonUtility.FromJson<ConnectionInfo>(msg);
    }

}

[System.Serializable]
public class NetworkMSGInspector : INetworkMSGBase
{
    public GameObject component;
    private INetworkMSGBase inst;
    private INetworkMSGBase gerInterface()
    {
        if (inst != null) return inst;
        Debug.Assert(component == null, "Inspector assin is wrong, null reference.");
        if (component == null) return null;
        inst = component.GetComponent<INetworkMSGBase>();
        Debug.Assert(inst == null, "GameObject doest not contain target interface.");
        return inst;
    }
    
    public void AddToOnRecived(EventHandler<RecieveDataEventArgs> action)
    {
        gerInterface().AddToOnRecived(action);
    }

    public void SendMsg(string msg)
    {
        gerInterface().SendMsg(msg);
    }
}
public interface INetworkMSGBase
{
    void SendMsg(string msg);
    void AddToOnRecived(System.EventHandler<RecieveDataEventArgs> action);
}
#endregion
#region CommandRelative
[System.Serializable]
public class CommandFactoryInspector : ICommandFactory
{
    public GameObject component;
    private ICommandFactory inst;
    private ICommandFactory gerInterface()
    {
        if (inst != null) return inst;
        Debug.Assert(component == null, "Inspector assin is wrong, null reference.");
        if (component == null) return null;
        inst = component.GetComponent<ICommandFactory>();
        Debug.Assert(inst == null, "GameObject doest not contain target interface.");
        return inst;
    }
   

    public ICommand PharseCommand(string msg)
    {
        return gerInterface().PharseCommand(msg);
    }
}
public interface ICommandFactory
{
    ICommand PharseCommand(string msg);
}
[System.Serializable]
public class CommandInspector : ICommand
{
    public GameObject component;
    private ICommand inst;

    private ICommand gerInterface()
    {
        if (inst != null) return inst;
        Debug.Assert(component == null, "Inspector assin is wrong, null reference.");
        if (component == null) return null;
        inst = component.GetComponent<ICommand>();
        Debug.Assert(inst == null, "GameObject doest not contain target interface.");
        return inst;
    }
   
    public void ExecuteAction()
    {
        gerInterface().ExecuteAction();
    }

    public bool FromMsg(string msg, out ICommand cmd)
    {
        return gerInterface().FromMsg(msg,out cmd);
    }

    public bool Verification(string msg)
    {
        return gerInterface().Verification(msg);
    }

    public string ToMsg()
    {
        return gerInterface().ToMsg();
    }


}
public interface ICommand
{
    void ExecuteAction();
    //void UndoAction();
    string ToMsg();
    bool FromMsg(string msg, out ICommand cmd);
    bool Verification(string msg);
}
#endregion
