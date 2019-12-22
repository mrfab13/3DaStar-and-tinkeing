using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wobble : MonoBehaviour
{
    public float verticalWaveSpeed;
    public float verticalMagnitude;
    public float rotateWaveSpeed;
    public float rotateMagnitude;

    Vector3 posInitial;
    Vector3 rotInitial;

    void Start()
    {
        posInitial = transform.position;
        rotInitial = transform.rotation.eulerAngles;
    }

    void Update()
    {
        // Position Wobble
        Vector3 pos;
        pos.x = 0;
        pos.y = (Mathf.Sin(Time.time * verticalWaveSpeed)) * verticalMagnitude;
        pos.z = 0;
        transform.position = posInitial + pos;

        // Rotation Wobble
        Vector3 rot;
        rot.x = 0;
        rot.y = 0;
        rot.z = (Mathf.Sin(Time.time * rotateWaveSpeed)) * rotateMagnitude;
        transform.rotation = Quaternion.Euler(rotInitial + rot);
    }
}


