using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selfdistrust : MonoBehaviour
{
    public float waitTime = 0.0f;

    void Update()
    {
        waitTime -= Time.deltaTime;
        if (waitTime <= 0.0f)
        {
            Destroy(this.gameObject);
        }
    }


}
