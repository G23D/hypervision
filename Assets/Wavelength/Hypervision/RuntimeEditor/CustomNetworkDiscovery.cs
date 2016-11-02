using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class CustomNetworkDiscovery : NetworkDiscovery {

	// Use this for initialization
	void Start () {
		Initialize ();
        StartAsClient();
        Debug.Log ("Started as Client");
	}

    public override void OnReceivedBroadcast(string fromAddress, string data) {
        string[] items = fromAddress.Split(':');
        int len = items.Length;
        string localAddress = items[len - 1];
        NetworkManager.singleton.networkAddress = localAddress;
        NetworkManager.singleton.StartClient ();
		Debug.Log ("Started as Client on Server:" + localAddress);
	}

}
