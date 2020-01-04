using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullethole : MonoBehaviour
{
    float timer = 0.0f;
    float maxtime = 20.0f;
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= maxtime)
        {
            Destroy(this.gameObject);
        }
    }
}
