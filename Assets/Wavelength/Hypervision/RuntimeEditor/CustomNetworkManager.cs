using UnityEngine;
using UnityEngine.Networking;
using HoloToolkit.Unity;

public class CustomNetworkManager : NetworkManager {

    GameObject selectedGameObject;
    GameObject editableObject;

    class InstructionMessage : MessageBase
    {
        public string instruction;
        public string comment;
    }

    const short InstructionMessageID = 888;

	public override void OnClientConnect(NetworkConnection conn) {
		//Debug.Log ("OnClientConnect");
        client.RegisterHandler(InstructionMessageID, OnInstruction);
    }

	public override void OnServerConnect(NetworkConnection conn) {
		//Debug.Log ("OnServerConnect");
	}

    void OnInstruction(NetworkMessage netMsg)
    {
        InstructionMessage msg = netMsg.ReadMessage<InstructionMessage>();
        //Debug.Log("InstructionMessage " + msg.instruction);

        // This code needs to be changed for a proper stack processor and eval function

        if (msg.instruction == "enter") {
			Debug.Log (GazeManager.Instance.FocusedObject);
            GazeManager.Instance.FocusedObject.GetComponent<TapToPush>().OnSelect();
        }

		Debug.Log("Instruction: " + msg.instruction);

        string[] tokens = msg.instruction.Split(' ');

        if (tokens[0] == "clr")
        {
            selectedGameObject.GetComponent<BoundingBox>().hide();
            selectedGameObject = null;
        }

        if (tokens[1] == "select")
        {
            selectedGameObject = GameObject.Find(tokens[0]);
            editableObject = selectedGameObject.GetComponent<BoundingBox>().targetObject;
            selectedGameObject.GetComponent<BoundingBox>().show();
        }

        if (tokens[1] == "dscl")
        {
            float scaleFactor;

            bool successfullyParsed = float.TryParse(tokens[0], out scaleFactor);
            if (successfullyParsed)
            {

                Vector3 scl1 = editableObject.transform.localScale;
                Vector3 scl2 = scl1 * scaleFactor;
                editableObject.transform.localScale = scl2;
                    
            }
        }

        if (tokens[1] == "drot")
        {
            float deltaGamma;

            bool successfullyParsed = float.TryParse(tokens[0], out deltaGamma);
            if (successfullyParsed)
            {
                Vector3 rot1 = editableObject.transform.rotation.eulerAngles;
                Vector3 rot2 = rot1 + new Vector3(0.0f, deltaGamma, 0.0f);
                editableObject.transform.rotation = Quaternion.Euler(rot2);
            }
        }

        if (tokens[1] == "dx")
        {
            float deltax;

            //GetCamera reference system

            Vector3 fwdLook = editableObject.transform.position - Camera.main.transform.position;
            fwdLook.y = 0;
            fwdLook = Vector3.Normalize(fwdLook);

            Quaternion camRotation = Quaternion.LookRotation(fwdLook); 

            bool successfullyParsed = float.TryParse(tokens[0], out deltax);
            if (successfullyParsed)
            {
                Vector3 pos1 = editableObject.transform.position;
                Vector3 pos2 = camRotation * new Vector3(deltax, 0.0f, 0.0f);
                editableObject.transform.position = pos1 + pos2;
            }
        }

        if (tokens[1] == "dy")
        {
            float deltay;

            //GetCamera reference system

            Vector3 fwdLook = editableObject.transform.position - Camera.main.transform.position;
            fwdLook.y = 0;
            fwdLook = Vector3.Normalize(fwdLook);

            Quaternion camRotation = Quaternion.LookRotation(fwdLook);

            bool successfullyParsed = float.TryParse(tokens[0], out deltay);
            if (successfullyParsed)
            {
                Vector3 pos1 = editableObject.transform.position;
                Vector3 pos2 = camRotation * new Vector3(0.0f, deltay, 0.0f);
                editableObject.transform.position = pos1 + pos2;
            }
        }

        if (tokens[1] == "dz")
        {
            float deltaz;

            //GetCamera reference system

            Vector3 fwdLook = editableObject.transform.position - Camera.main.transform.position;
            fwdLook.y = 0;
            fwdLook = Vector3.Normalize(fwdLook);

            Quaternion camRotation = Quaternion.LookRotation(fwdLook);

            bool successfullyParsed = float.TryParse(tokens[0], out deltaz);
            if (successfullyParsed)
            {
                Vector3 pos1 = editableObject.transform.position;
                Vector3 pos2 = camRotation * new Vector3(0.0f, 0.0f, deltaz);
                editableObject.transform.position = pos1 + pos2;
            }
        }
    }
}


