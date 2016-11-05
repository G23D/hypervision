using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using HoloToolkit.Unity;

class SelectMessage : MessageBase {

    public int uuid;
    public string comment;

}

public class TapToPush : MonoBehaviour
{
    public bool taptest = false;

    public const short SelectMessageID = 889;

    public GameObject NetManager;

    public void OnSelect()
    {

        SelectMessage msg = new SelectMessage();

        // Send object ID to GUI
        msg.uuid = this.GetInstanceID();
        msg.comment = "This is a custom comment";

        //Debug.Log(NetManager.GetComponent<CustomNetworkManager>().client);

        CustomNetworkManager.singleton.client.Send(SelectMessageID, msg);
        //NetworkManager.singleton.client.Send(SelectMessageID, msg);
        //NetworkClient.allClients[0].Send(SelectMessageID, msg);
    }

    void Update() {

        if (taptest) {
            OnSelect();
            taptest = false;
        }
    }

}
