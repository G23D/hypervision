using UnityEngine;
using System.Collections;

public class BoundingBox : MonoBehaviour {

    Bounds bbox;
    public GameObject targetObject;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Bounds bbox = GetMaxBounds(targetObject);
        Vector3 bboxSize = new Vector3(bbox.size.z, bbox.size.y, bbox.size.x); //Can't figure out why bbox is swapped in x and z, but it works!
        transform.position = bbox.center;
        transform.localScale = bboxSize;
    }

    Bounds GetMaxBounds(GameObject g)
    {
        var b = new Bounds();
        if (g.GetComponent<Renderer>()) {
           b = g.GetComponent<Renderer>().bounds;
        }
        foreach (Renderer r in g.GetComponentsInChildren<Renderer>()){
            if (b == new Bounds()) {
                b = r.bounds;
            } else {
                b.Encapsulate(r.bounds);
            }
            
        }
        return b;
    }
}
