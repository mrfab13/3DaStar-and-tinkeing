using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShowPath : MonoBehaviour
{
    public Vector3 posA;
    public NavMeshAgent agent;
    public float lifetime;
    private float spawnDely = 0.5f;
    private float timer;

    void Start()
    {
        posA = GameObject.Find("spawner").GetComponent<spawner>().posA;
        lifetime = this.GetComponent<TrailRenderer>().time;
    }


    void Update()
    {
        agent.SetDestination(posA);
        if (spawnDely >= 0.0f)
        {
            spawnDely -= Time.deltaTime;
        }
        if (spawnDely < 0.0f)
        {
            if (hasarrived() == true || GameObject.Find("spawner").GetComponent<spawner>().currentGameSatae != spawner.gamestate.pre)
            {
                StartCoroutine(selfdestruct(lifetime));
            }
        }
    }

    public bool hasarrived()
    {
        if (!agent.pathPending || agent.velocity.sqrMagnitude <= 0.1f)
        {
            if (agent.remainingDistance <= agent.stoppingDistance || agent.velocity.sqrMagnitude <= 0.1f)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude <= 0.1f)
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
