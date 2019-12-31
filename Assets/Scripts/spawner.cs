using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public enum gamestate
    { 
        pre,
        wave,
        end
    }
    public GameObject trail;
    public gamestate currentGameSatae = gamestate.pre;

    public Vector3 posA;
    public float timer = 0.0f;
    public float trailSpawnerDelay = 1.0f;

    void Update()
    {
        if (currentGameSatae == gamestate.pre)
        {
            timer += Time.deltaTime;
            if (timer >= trailSpawnerDelay)
            {
                timer = 0.0f;
                Instantiate(trail, this.transform.position, Quaternion.identity);
            }
        }
    }
}
