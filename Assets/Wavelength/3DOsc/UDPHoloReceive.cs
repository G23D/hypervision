using UnityEngine;
using System;
using System.IO;

#if !UNITY_EDITOR
using Windows.Networking.Sockets;
#endif

public class UDPHoloReceive : MonoBehaviour
{
#if !UNITY_EDITOR
    DatagramSocket socket;

    // use this for initialization
    async void Start()
    {
        Debug.Log("Waiting for a connection...");

        socket = new DatagramSocket();
        socket.MessageReceived += Socket_MessageReceived;

        try
        {
            await socket.BindEndpointAsync(null, "8051");
        }
        catch (Exception e)
        {
            Debug.Log(e.ToString());
            Debug.Log(SocketError.GetStatus(e.HResult).ToString());
            return;
        }

        Debug.Log("exit start");

    }

#endif

    // Update is called once per frame
    void Update()
    {

    }

#if !UNITY_EDITOR
    private async void Socket_MessageReceived(Windows.Networking.Sockets.DatagramSocket sender,
        Windows.Networking.Sockets.DatagramSocketMessageReceivedEventArgs args)
    {
        //Read the message that was received from the UDP echo client.
        Stream streamIn = args.GetDataStream().AsStreamForRead();
        StreamReader reader = new StreamReader(streamIn);
        string message = await reader.ReadLineAsync();

        Debug.Log("MESSAGE: " + message);
    }
#endif
}