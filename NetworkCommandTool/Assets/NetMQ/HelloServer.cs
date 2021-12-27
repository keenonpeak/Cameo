using System.Threading;
using NetMQ;
using NetMQ.Sockets;
using UnityEngine;
public class HelloServer : MonoBehaviour
{
    private Thread _listenerWorker;

    private bool _listenerCancelled;

    public delegate string MessageDelegate(string message);

    private MessageDelegate _messageDelegate;

    private const long ContactThreshold = 1000;

    public bool Connected;
    private void ListenerWork()
    {
        AsyncIO.ForceDotNet.Force();
        using (var server = new ResponseSocket())
        {
            server.Bind("tcp://*:8003");

            while (!_listenerCancelled)
            {
                try
                {
                    string message;
                    if(!server.TryReceiveFrameString(out message)) continue;
                   // var message = server.ReceiveFrameString();
                    Debug.Log("Received " + message);
                    // processing the request
                    Thread.Sleep(100);

                    Debug.Log("Sending data to client");
                    server.SendFrame("data fron server");
                }
                catch(System.Exception e)
                {
                    Debug.Log(e);
                }
            }
            server.Dispose();
        }
        NetMQConfig.Cleanup(false);
    }

    void Start()
    {
        _listenerWorker = new Thread(ListenerWork);
        StartServer();

    }
    public void StartServer()
    {
        _listenerCancelled = false;
        _listenerWorker.Start();
    }

    public void StopServer()
    {
        _listenerCancelled = true;
        _listenerWorker.Join();
    }
    private void OnDestroy()
    {
        StopServer();
    }
    void Update()
    {
        
    }
}
