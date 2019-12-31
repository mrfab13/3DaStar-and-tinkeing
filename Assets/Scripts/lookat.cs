using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookat : MonoBehaviour
{
    public Transform target;
    void Update()
    {


        transform.LookAt(new Vector3(target.position.x, gameObject.transform.position.y + gameObject.GetComponentInParent<Transform>().position.y, target.position.z));
    }
}
