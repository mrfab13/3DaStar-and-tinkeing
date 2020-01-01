using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popoutBlock : MonoBehaviour
{
    bool newblock = true;
    public void OnCollisionStay(Collision collision)
    {
        if (newblock == true)
        {
            newblock = true;
            foreach (ContactPoint contact in collision.contacts)
            {
                float PointToMid = Vector3.Distance(gameObject.transform.position, gameObject.GetComponent<BoxCollider>().bounds.ClosestPoint(contact.point));
                float unknowen = gameObject.GetComponent<BoxCollider>().bounds.extents.x * 2 - (Mathf.Sqrt(Mathf.Pow(PointToMid, 2) + Mathf.Pow(gameObject.GetComponent<BoxCollider>().bounds.extents.x, 2) - Mathf.Pow(gameObject.GetComponent<BoxCollider>().bounds.extents.x, 2)) + gameObject.GetComponent<BoxCollider>().bounds.extents.x);
                if (unknowen > 0)
                {
                    gameObject.transform.position += contact.normal * unknowen;
                    Debug.DrawLine(gameObject.transform.position, gameObject.GetComponent<BoxCollider>().bounds.ClosestPoint(contact.point));
                    Debug.DrawRay(contact.point, contact.normal * 10, Color.white);
                    Debug.Log(unknowen);
                }

            }
        }
    }
}
