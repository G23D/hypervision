using UnityEngine;
using System.Collections;
using System;

public class EditorManager : MonoBehaviour {

    public GameObject[] handledObjects;
    public GameObject NetManager;

	// Use this for initialization
	void Start () {

        handledObjects = GameObject.FindGameObjectsWithTag("Editable");
        foreach (GameObject ho in handledObjects) {
            GameObject handle = Instantiate(Resources.Load("handle") as GameObject);
            handle.name = Guid.NewGuid().ToString();
            handle.GetComponent<BoundingBox>().targetObject = ho;
            handle.GetComponent<TapToPush>().NetManager = NetManager;
        }
	}
}
