using System.Collections.Concurrent;
using System.Threading;
using NetMQ;
using UnityEngine;
using NetMQ.Sockets;
using Sirenix.OdinInspector;

public class HelloClient : MonoBehaviour
{
    private  Thread _listenerWorker;
    private bool _listenerCancelled;

    public delegate void MessageDelegate(string message);

    private readonly MessageDelegate _messageDelegate;

    private readonly ConcurrentQueue<string> _messageQueue = new ConcurrentQueue<string>();
    private void ListenerWork()
    {
        AsyncIO.ForceDotNet.Force();
        using (var client = new RequestSocket())
        {
            client.Connect("tcp://localhost:8003");
        
            while (!_listenerCancelled)
            {
               

                var message = client.ReceiveFrameString();
                Debug.Log("Received " + message);
            }
            client.Disconnect("tcp://localhost:8003");
            client.Close();
        }
        NetMQConfig.Cleanup();
    }
   
    public void SendOneHello()
    {
        AsyncIO.ForceDotNet.Force();
        using (var client = new RequestSocket())
        {
            client.Connect("tcp://localhost:8003");

            Debug.Log("Sending data to server");
            client.SendFrame("data fron client");
            var message = client.ReceiveFrameString();
            Debug.Log("Received " + message);
            client.Disconnect("tcp://localhost:8003");
           
            client.Dispose();
        }
    }

    [Button]
    void StartOneSend()
    {

        Thread __oneWorker = new Thread(SendOneHello);
      
        __oneWorker.Start();
    }

    public void StartClient()
    {
        _listenerWorker = new Thread(ListenerWork);
        _listenerCancelled = false;
        _listenerWorker.Start();
    }
   
    public void StopClient()
    {
        _listenerCancelled = true;
    }

    private void OnDestroy()
    {
        NetMQConfig.Cleanup(false);
    }
}
