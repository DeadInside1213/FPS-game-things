using UnityEngine;

public class LightControll : MonoBehaviour
{

    public float lightTime = 1f;
    public Light light;
    
    public Gradient gradient;
    public float RotationSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RotationSpeed = 360f / (lightTime * 60f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(Vector3.right, RotationSpeed * Time.deltaTime);
        if (light != null && gradient != null)
        {
            float time = Mathf.PingPong(Time.time / (lightTime * 30f), 1f);
            light.color = gradient.Evaluate(time);
        }
    }
}
