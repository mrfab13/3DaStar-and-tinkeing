using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popoutBlock : MonoBehaviour
{
    public void OnCollisionStay(Collision collisionInfo)
    {
        Debug.Log(collisionInfo);
    }
}
