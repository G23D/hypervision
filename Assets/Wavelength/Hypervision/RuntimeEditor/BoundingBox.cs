using UnityEngine;
using HoloToolkit.Unity;
using System.Collections;

public class BoundingBox : MonoBehaviour {

    Bounds bbox;
    public GameObject targetObject;
    //public GameObject SelectCursor;
    //public bool selected;
	
	// Update is called once per frame
	void Update () {
        Bounds bbox = GetMaxBounds(targetObject);

        if (GetComponent<MyTapToPlace>().placing)
        {
            targetObject.transform.position = transform.position;
            //SelectCursor.gameObject.SetActive(true);
            //SelectCursor.transform.position = transform.position;
            //SelectCursor.transform.rotation = transform.rotation;
            //SelectCursor.transform.localScale = transform.localScale;

        }
        else {
            transform.position = bbox.center;
            transform.localScale = bbox.size;
            //SelectCursor.gameObject.SetActive(false);

        }
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
