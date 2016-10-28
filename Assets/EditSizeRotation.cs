using UnityEngine;
using System.Collections;

public class EditSizeRotation : MonoBehaviour {

    public void processMessage(string message) {

        Vector3 localScale = transform.localScale;
        Vector3 rotation = transform.rotation.eulerAngles;

        if (message == "Size *1.025") {
            localScale *= 1.025f;
            transform.localScale = localScale;
        }
        if (message == "Size /1.025")
        {
            localScale /= 1.025f;
            transform.localScale = localScale;
        }
        if (message == "RotY 5")
        {
            rotation.y += 5f;
            transform.rotation = Quaternion.Euler(rotation);
        }
        if (message == "RotY -5")
        {
            rotation.y -= 5f;
            transform.rotation = Quaternion.Euler(rotation);
        }
    }
}
