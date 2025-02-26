using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera cam;
    private float xRotation = 0.0f;
    public float xSensitivity = 30.0f;
    public float ySensitivity = 30.0f;

    [HideInInspector]
    public float xOrigin;
    [HideInInspector]
    public float yOrigin;
    
    private void Start()
    {
        xOrigin = xSensitivity;
        yOrigin = ySensitivity;
    }
    
    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;
        
        // Calculate camera rotation for looking up and down.
        xRotation -= (mouseY * Time.deltaTime) * ySensitivity;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
        
        // Apply to camera transform.
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        
        // Rotate player to look left and right.
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensitivity);
    }
}
