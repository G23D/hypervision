using UnityEngine;
using System.Collections;

public class TraceControl : MonoBehaviour
{

    public ParticleSystem Trace;
    public float min_x;
    public float max_x;
    public float min_y;
    public float max_y;
    public float timeDelta;

    private float x_local_ = 0.0f;


    public Vector2 dual_signal(float time)
    {
        float x = 0.5f * Mathf.Sin(0.2f * time) * Mathf.Sin(20f * time);
        float y = 0.5f * Mathf.Cos(0.234f * time) * Mathf.Cos(20f * time);
        return new Vector2(x, y);
    }

    // Update is called once per frame
    void Update()
    {

        Trace.startLifetime = timeDelta;
        Vector2 signal = dual_signal(Time.time);
        float scaledTime = Time.time / timeDelta;
        float phaseTime = scaledTime - (int)scaledTime;

        float x_local = phaseTime - 0.5f;
        float y_local = (signal.y - min_y) / (max_y - min_y) - 0.5f;
        float z_local = (signal.x - min_x) / (max_x - min_x) - 0.5f;

        if (((x_local_ - x_local) >= 0)
            || (Mathf.Abs(y_local) > 0.5f) && (transform.localScale.y > 0.01f)
            || (Mathf.Abs(z_local) > 0.5f) && (transform.localScale.z > 0.01f)
            )
        {
            Trace.startLifetime = 0.0f;
        }

        x_local_ = x_local;
        Trace.transform.localPosition = new Vector3(x_local, y_local, z_local);

    }
}
