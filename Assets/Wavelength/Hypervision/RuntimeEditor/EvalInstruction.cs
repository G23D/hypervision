using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class EvalInstruction : NetworkBehaviour
{
    class InstructionMessage : MessageBase
    {
        public string instruction;
        public string comment;
    }

    const short InstructionMessageID = 888;

    public void Init()
    {
        NetworkServer.RegisterHandler(InstructionMessageID, OnInstruction);
    }

     void OnInstruction(NetworkMessage netMsg)
    {
        InstructionMessage msg = netMsg.ReadMessage<InstructionMessage>();
        Debug.Log("InstructionMessage " + msg.instruction);
    }
}
