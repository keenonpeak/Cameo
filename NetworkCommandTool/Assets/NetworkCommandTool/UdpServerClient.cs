using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using UnityEngine;
public class UdpSocketHoster
{
    #region Fields (3) 

    public Thread mListenThread;
    private int mRecieverBuffer = 1024;
    private Socket mSocket;

    #endregion Fields 

    #region Properties (3) 

    public string Ip
    {
        get;
        set;
    }

    public int Port
    {
        get;
        set;
    }

    public int RecieverBuffer
    {
        get { return mRecieverBuffer; }
        set { mRecieverBuffer = value; }
    }

    #endregion Properties 

    #region Delegates and Events (3) 

    // Events (3) 

    public event EventHandler<RecieveDataEventArgs> RecievedData;

    public event EventHandler StartListening;

    public event EventHandler StopListening;

    #endregion Delegates and Events 

    #region Methods (4) 

    // Public Methods (3) 

    public void readyToListen()
    {
        if (StartListening != null)
        {
            StartListening(this, new EventArgs());
        }
        mListenThread = new Thread(new ParameterizedThreadStart(startListen));
        mListenThread.Start();
    }

    public void Start(string ip, int port)
    {
        this.Ip = ip;
        this.Port = port;
        readyToListen();
    }

    public void Stop()
    {
        if (StopListening != null)
        {
            StopListening(this, new EventArgs());
        }

        mSocket.Close();
        mListenThread.Abort();
    }
    // Private Methods (1) 
    
   
    public void Send(object data)
    {
        mSocket.EnableBroadcast = true;
        mSocket.SendBufferSize = mRecieverBuffer;
        //Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

        //Serialize Data
        byte[] package = new byte[mRecieverBuffer];
        BinaryFormatter bf = new BinaryFormatter();
        MemoryStream stream = new MemoryStream();
        bf.Serialize(stream, data);
        package = stream.ToArray();

        //Setting Server Endpoint
        IPEndPoint endPoint = new IPEndPoint(IPAddress.Broadcast, Port);// IPAddress.Broadcast, Port);

        //Send Data
        //using (var netStream = new NetworkStream(mSocket))
        //{
        //    if (netStream.CanWrite)
        //    {
        //        netStream.Write(package, 0, package.Length);
        //        netStream.Flush();
        //    }
            
        //}
        mSocket.SendTo(package, package.Length, SocketFlags.None, endPoint);
    }
    
    private void startListen(object sender)
    {
        //Setting Endpoint
        IPEndPoint endpoint = new IPEndPoint(IPAddress.Any, Port);
        mSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

        mSocket.ReceiveBufferSize = mRecieverBuffer;
        //Binding Endpoint
        mSocket.Bind(endpoint);

        //Getting Client Ip
        IPEndPoint clientEndpoint = new IPEndPoint(IPAddress.Any, 0);
        EndPoint Remote = (EndPoint)(clientEndpoint);

        //Start loop for receiving data
        while (true)
        {
            try
            {
                int recv;
                byte[] receivePackage = new byte[mRecieverBuffer];

                //Receive data from client
                recv = mSocket.ReceiveFrom(receivePackage, ref Remote);
                //using (var netStream = new NetworkStream(mSocket))
                //{
                //    recv = netStream.Read(receivePackage, 0, receivePackage.Length);
                //}
                
                //Deserialize data
                BinaryFormatter bf = new BinaryFormatter();
                MemoryStream stream = new MemoryStream(receivePackage);
                object data = bf.Deserialize(stream);

                if (RecievedData != null)
                {
                    RecievedData(this, new RecieveDataEventArgs(data));
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }

    #endregion Methods 
}
public class RecieveDataEventArgs : EventArgs
{
    #region Fields (1) 

    public object mData;

    #endregion Fields 

    #region Constructors (1) 

    public RecieveDataEventArgs(object data)
    {
        this.mData = data;
    }

    #endregion Constructors 

    #region Properties (1) 

    public object Data
    {
        get
        {
            return mData;
        }
    }

    #endregion Properties 
}

public class UdpServerClient : MonoBehaviour
{
    public bool test = false;
    public UdpSocketHoster hoster;
    void Awake()
    {
        hoster = new UdpSocketHoster();
        
        hoster.RecievedData += (o, e) =>
        {
            
            if(e.Data.GetType().ToString()== "System.String")
            {
                //Debug.Log(e.Data);
            }
            else if(e.Data.GetType().ToString() == "System.String[]")
            {
                string[] namelist = (string[])e.Data;
                foreach (var obj in namelist) Debug.Log(obj);
            }
            else
            {
                Debug.Log(e.Data.GetType().ToString());
                print(e.Data.ToString());
            }
        };
        hoster.StartListening += (o, e) => Debug.Log("Start Hosting...");
        hoster.Start("192.123.56.1", 8003);
    }
    private void OnDestroy()
    {
        Debug.Log("Stop udp host server.s");
        hoster.Stop();
        hoster = null;
    }
    public void SendData(object obj)
    {
        hoster.Send(obj);
    }
    void TestSendData()
    {
        Debug.Log("Send test data.");
        hoster.Send("192.123.56.1");
        hoster.Send("8003");
    }
    void Update()
    {
        if(test)
        {
            test = false;
            TestSendData();
        }
    }
}
