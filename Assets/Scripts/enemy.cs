using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    public float max = 100.0f;
    public float hp = 100.0f;

    public NavMeshAgent agent;

    public bool tofrom = true;
    public Vector3 posA;
    public Vector3 posB;



    void Update()
    {
        gameObject.transform.GetChild(0).GetChild(0).GetComponent<Image>().fillAmount = hp / max;

        if (tofrom == true)
        {
            agent.SetDestination(posA);
            if (hasarrived() == true)
            {
                tofrom = false;
            }
        }
        else 
        {
            agent.SetDestination(posB);
            if (hasarrived() == true)
            {
                tofrom = true;
            }
        }



        if (hp <= 0.0f)
        {
            Destroy(this.gameObject);
        }
    }

    public bool hasarrived()
    {
        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    return true;
                }
            }
        }

        return false;
    }
}
