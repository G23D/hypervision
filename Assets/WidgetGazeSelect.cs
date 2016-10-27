using UnityEngine;
using System.Collections;

/// <summary>
/// FocusedObjectMessageReceiver class shows how to handle messages sent by FocusedObjectMessageSender.
/// This particular implementatoin controls object appearance by changing its color when focused.
/// </summary>
public class WidgetGazeSelect : MonoBehaviour
{

    public GameObject RxGameObject;
    public Color FocusedColor = Color.green;

    private Material material;
    private Color originalColor;

    string lastCommand;
    bool repeatLastCommand = false;
    float repeatTime = 0.25f; // Repeat time in seconds
    float ellapsedTime = 0.25f;

    private void Start()
    {
        material = GetComponent<Renderer>().material;
        originalColor = material.color;
    }

    private void Update() {

        if (repeatLastCommand) {
            if (ellapsedTime <= 0.0f){
                RxGameObject.GetComponent<EditSizeRotation>().processMessage(lastCommand);
                ellapsedTime = repeatTime;
            }
            else {
                ellapsedTime -= Time.deltaTime;
            }
        } 
    }

    public void OnGazeEnter()
    {
        material.color = FocusedColor;
        RxGameObject.GetComponent<EditSizeRotation>().processMessage(this.name);
        lastCommand = this.name;
        repeatLastCommand = true;
    }

    public void OnGazeLeave()
    {
        material.color = originalColor;
        repeatLastCommand = false;
        ellapsedTime = repeatTime;
    }
}