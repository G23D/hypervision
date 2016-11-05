using UnityEngine;
using UnityEngine.Networking;
using HoloToolkit.Unity;

public class CustomNetworkManager : NetworkManager {

    class InstructionMessage : MessageBase
    {
        public string instruction;
        public string comment;
    }

    const short InstructionMessageID = 888;

	public override void OnClientConnect(NetworkConnection conn) {
		Debug.Log ("OnClientConnect");
        client.RegisterHandler(InstructionMessageID, OnInstruction);
    }

	public override void OnServerConnect(NetworkConnection conn) {
		Debug.Log ("OnServerConnect");
	}

    void OnInstruction(NetworkMessage netMsg)
    {
        InstructionMessage msg = netMsg.ReadMessage<InstructionMessage>();
        Debug.Log("InstructionMessage " + msg.instruction);

        // if instruction is enter, select object being gazed

        if (msg.instruction == "enter") {
            GazeManager.Instance.FocusedObject.GetComponent<TapToPush>().OnSelect();
        }

    }

}


