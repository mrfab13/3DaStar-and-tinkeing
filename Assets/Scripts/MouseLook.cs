using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSens = 100.0f;
    public float mouseX;
    public float mouseY;
    float pitch;
    public Transform body;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float yaw = transform.localEulerAngles.y;
 
        yaw += Input.GetAxis("Mouse X") * mouseSens;

        float pitchDelta = -Input.GetAxis("Mouse Y") * mouseSens;
        pitch += pitchDelta;
        pitch = Mathf.Clamp(pitch, -89.9f, 89.9f);

        transform.localEulerAngles = new Vector3(pitch, 0, 0);

        body.Rotate(Vector3.up, yaw);
    }
}
