using UnityEngine;
using System.Collections;

public class TraceControl : MonoBehaviour {

    public ParticleSystem Trace;
    public float min_x;
    public float max_x;
    public float min_y;
    public float max_y;
    public float timeDelta;


    public Vector2 dual_signal(float time) {
        float x = Mathf.Sin(3.5f * time + 25f * Mathf.Deg2Rad);
        float y = Mathf.Cos(2.3f * time - 145f * Mathf.Deg2Rad);
        return new Vector2(x, y);
    }

	// Update is called once per frame
	void Update () {

        Trace.startLifetime = timeDelta;
        Vector2 signal = dual_signal(Time.time);
        float scaledTime = Time.time / timeDelta;
        float phaseTime = scaledTime - (int)scaledTime;

        float x_local =  phaseTime - 0.5f;
        float y_local = (signal.y - min_y) / (max_y - min_y) - 0.5f;
        float z_local = (signal.x - min_x) / (max_x - min_x) - 0.5f;

        Trace.transform.localPosition = new Vector3(x_local, y_local, z_local);

	}
}
