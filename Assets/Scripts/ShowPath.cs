using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShowPath : MonoBehaviour
{
    public Vector3 posA;
    public NavMeshAgent agent;
    public float lifetime;

    void Start()
    {
        posA = GameObject.Find("spawner").GetComponent<spawner>().posA;
        lifetime = this.GetComponent<TrailRenderer>().time;
    }


    void Update()
    {
        agent.SetDestination(posA);

        if (hasarrived() == true)
        {
            StartCoroutine(selfdestruct(lifetime));
        }

    }

    public bool hasarrived()
    {
        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance || agent.velocity.sqrMagnitude <= 0.3f)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude <= 0.3f)
                {
                    return true;
                }
            }
        }

        return false;
    }

    public IEnumerator selfdestruct(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(this.gameObject);
    }
}
