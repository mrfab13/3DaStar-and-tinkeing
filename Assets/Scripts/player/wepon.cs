using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class wepon : MonoBehaviour
{
    public float fireRate = 1.0f;
    public float timer = 0.0f;
    public NavMeshSurface surface;
    public Animator pew;
    public GameObject block;
    private NavMeshPath path;

    void Start()
    {
        path = new NavMeshPath();
    }

    void Update()
    {
        if (timer > 0.0f)
        {
            timer -= Time.deltaTime;
        }

        if (GameObject.Find("spawner").GetComponent<spawner>().currentGameSatae == spawner.gamestate.wave)
        {
            if (Input.GetButton("Fire1") == true)
            {
                if (timer <= 0.0f)
                {
                    StartCoroutine(shot());
                    RaycastHit Hit;
                    Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Hit);
                    if (Hit.collider.gameObject.transform.tag == "enemy")
                    {
                        Hit.collider.gameObject.GetComponent<enemy>().hp -= 25.0f;
                    }
                }
            }
        }


        if (GameObject.Find("spawner").GetComponent<spawner>().currentGameSatae == spawner.gamestate.pre)
        {
            RaycastHit Hit;
            Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Hit);
            if (Input.GetButton("Fire1") == true)
            {
                if (Hit.collider.gameObject.layer == 9 || Hit.collider.gameObject.tag == "block")
                {
                    Instantiate(block, Hit.point, Quaternion.identity);

                    surface.BuildNavMesh();
                }
            }

            if (Input.GetButton("Fire2") == true)
            {
                if (Hit.collider.tag == "block")
                {
                    Destroy(Hit.collider.gameObject);
                    surface.BuildNavMesh();
                }
            }

            if (Input.GetButton("Submit") == true)
            {
                NavMesh.CalculatePath(GameObject.Find("spawner").transform.position, GameObject.Find("spawner").GetComponent<spawner>().posA, NavMesh.AllAreas, path);

                if (path.status == NavMeshPathStatus.PathComplete)
                {
                    GameObject.Find("spawner").GetComponent<spawner>().currentGameSatae = spawner.gamestate.wave;
                }
                else
                {
                    Debug.Log("no valid path");
                }

                for (int i = 0; i < path.corners.Length - 1; i++)
                {
                    Debug.DrawLine(path.corners[i], path.corners[i + 1], Color.red);
                }
            }

        }


    }

    IEnumerator shot()
    {
        timer = fireRate;
        gameObject.GetComponentInParent<AudioSource>().Play();
        pew.Play("pew");
        GameObject.Find("muzzle").gameObject.transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        GameObject.Find("muzzle").gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }
}
