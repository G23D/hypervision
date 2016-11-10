using UnityEngine;
using HoloToolkit.Unity;
using System.Collections;

public class BoundingBox : MonoBehaviour {

    Bounds bbox;
    public GameObject targetObject;
    public bool visibleBox;
    public Color color;
    public Transform cursor;
    //public GameObject SelectCursor;
    //public bool selected;

    // Update is called once per frame

    void Start() {
        cursor = transform.FindChild("Cursor");
    }

	void Update () {
        Bounds bbox = GetMaxBounds(targetObject);
        transform.position = bbox.center;
        transform.localScale = bbox.size;        
    }

    public void show() {
        cursor.gameObject.SetActive(true);
    }

    public void hide() {
        cursor.gameObject.SetActive(false);
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
