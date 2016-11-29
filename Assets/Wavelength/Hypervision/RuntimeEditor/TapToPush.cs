using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using HoloToolkit.Unity;

class SelectMessage : MessageBase {

    public string uuid;
    public string comment;

}

public class TapToPush : MonoBehaviour
{
    [Tooltip("Supply a friendly name for the anchor as the key name for the WorldAnchorStore.")]
    public string SavedAnchorFriendlyName = "SavedAnchorFriendlyName";

    /// <summary>
    /// Manages persisted anchors.
    /// </summary>
    private WorldAnchorManager anchorManager;

    /// <summary>
    /// Controls spatial mapping.  In this script we access spatialMappingManager
    /// to control rendering and to access the physics layer mask.
    /// </summary>
    private SpatialMappingManager spatialMappingManager;

    public bool taptest = false;

    public const short SelectMessageID = 889;

    public GameObject NetManager;


    private void Start()
    {
        // Make sure we have all the components in the scene we need.
        anchorManager = WorldAnchorManager.Instance;
        if (anchorManager == null)
        {
            Debug.LogError("This script expects that you have a WorldAnchorManager component in your scene.");
        }

        spatialMappingManager = SpatialMappingManager.Instance;
        if (spatialMappingManager == null)
        {
            Debug.LogError("This script expects that you have a SpatialMappingManager component in your scene.");
        }

        if (anchorManager != null && spatialMappingManager != null)
        {
            anchorManager.AttachAnchor(this.gameObject, SavedAnchorFriendlyName);
        }
        else
        {
            // If we don't have what we need to proceed, we may as well remove ourselves.
            Destroy(this);
        }
    }

    public void OnSelect()
    {

        SelectMessage msg = new SelectMessage();

        // Send object ID to GUI
        msg.uuid = this.gameObject.name;
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
