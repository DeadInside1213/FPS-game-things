using UnityEngine;

public class can : MonoBehaviour
{
    public int small = 10;
    public int large = 100;
    
    
    void Start()
        {
            Camera camera = GetComponent<Camera>();
            float[] distances = new float[32];
            distances[8] = small;
            distances[9] = large;
            camera.layerCullDistances = distances;
        }
}
