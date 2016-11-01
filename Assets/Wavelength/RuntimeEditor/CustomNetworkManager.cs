using UnityEngine;
using UnityEngine.Networking;

public class CustomNetworkManager : NetworkManager {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	public override void OnClientConnect(NetworkConnection conn) {
	
		Debug.Log ("OnClientConnect");
	}

	public override void OnServerConnect(NetworkConnection conn) {

		Debug.Log ("OnServerConnect");
	}
}
