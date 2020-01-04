using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookat : MonoBehaviour
{
    public Transform target;

    void Start()
    {
        target = GameObject.Find("player").gameObject.transform;
    }

    void Update()
    {

        transform.LookAt(new Vector3(target.position.x, this.gameObject.transform.position.y, target.position.z));
    }
}
