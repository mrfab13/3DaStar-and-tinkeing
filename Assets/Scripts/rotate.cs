using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    public float degrees;
    void Update()
    {
        this.gameObject.transform.Rotate(0, 0, degrees * Time.deltaTime);
    }
}
