using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class wepon : MonoBehaviour
{
    public float fireRate = 1.0f;
    public float placerate = 0.1f;
    public float timer = 0.0f;
    public float MaxRange = 15.0f;
    public float MaxDamage = 25.0f;
    public float pellets = 8.0f;
    public float bulletSpread = 0.1f;
    public float ADSSpeed = 2.0f;
    

    public NavMeshSurface surface;
    public Animator pew;
    public GameObject block;
    public GameObject bulletHole;
    public GameObject damagedText;
    private NavMeshPath path;
    private bool oncePre = true;
    private bool onceWave = true;
    private bool onceADS = false;
    private IEnumerator spreadcoro;

    void Start()
    {
        spreadcoro = bulletspread(bulletSpread, bulletSpread);
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
            if (onceWave == true)
            {
                onceWave = false;
                oncePre = true;
            }

            if (Input.GetButton("Fire2") == true && onceADS == true)
            {
                onceADS = false;
                StopCoroutine(spreadcoro);
                spreadcoro = bulletspread(0.02f, bulletSpread);
                StartCoroutine(spreadcoro);
                //bulletSpread = 0.02f;
            }
            if (Input.GetButton("Fire2") == false && onceADS == false)
            {
                onceADS = true;
                StopCoroutine(spreadcoro);
                spreadcoro = bulletspread(0.1f, bulletSpread);
                StartCoroutine(spreadcoro);
                //bulletSpread = 0.1f;
            }

            if (Input.GetButton("Fire1") == true)
            {
                if (timer <= 0.0f)
                {
                    StartCoroutine(shot());
                    for (int j = 0; j < pellets; j++)  
                    {
                        RaycastHit[] Hits;



                        float yrand = Random.Range(bulletSpread, -bulletSpread);
                        float xrand = Random.Range(Mathf.Sqrt(Mathf.Pow(bulletSpread, 2) - Mathf.Pow(yrand, 2)), -Mathf.Sqrt(Mathf.Pow(bulletSpread, 2) - Mathf.Pow(yrand, 2)));
                        Vector3 vec3dir = new Vector3(xrand, yrand, 1);



                        Hits = Physics.RaycastAll(transform.position, transform.TransformDirection(vec3dir), MaxRange);
                        for (int i = 0; i < Hits.Length; i++)
                        {
                            RaycastHit Hit = Hits[i];

                            if (Hit.collider.gameObject.transform.tag == "enemy")
                            {
                                GameObject enemy = Hit.collider.gameObject;
                                Vector3 hitposition = Hit.point + (Hit.normal * 0.4f);
                                GameObject text = Instantiate(damagedText, hitposition, Quaternion.identity);
                                text.transform.SetParent(Hit.collider.gameObject.transform, true);

                                float dist = Vector3.Distance(this.gameObject.transform.position, Hit.point);
                                float falloff = Mathf.Clamp(1.5f * Mathf.Cos(Mathf.Pow(dist / MaxRange, 0.3f) * (Mathf.PI / 2)), 0.0f, 1.0f);
                                float damage = falloff * (MaxDamage / pellets);

                                text.gameObject.transform.GetChild(0).GetComponent<Text>().text = "-" + damage.ToString("F0");
                                enemy.GetComponent<enemy>().hp -= damage;
                            }

                            if (Hit.collider.gameObject.layer == 9) //ground and wall
                            {
                                Quaternion hitRotation = Quaternion.FromToRotation(Vector3.forward, Hit.normal);
                                Vector3 hitposition = Hit.point + (Hit.normal * 0.01f);

                                GameObject hole = Instantiate(bulletHole, hitposition, hitRotation);

                            }
                        }
                    }
                }
            }
        }


        if (GameObject.Find("spawner").GetComponent<spawner>().currentGameSatae == spawner.gamestate.pre)
        {
            if (oncePre == true)
            {
                oncePre = false;
                onceWave = true;
                bulletSpread = 0.001f;
            }

            RaycastHit Hit;
            Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Hit);
            if (Input.GetButton("Fire1") == true)
            {
                if (timer <= 0.0f)
                {
                    timer = placerate;
                    if (Hit.collider.gameObject.layer == 9 || Hit.collider.gameObject.tag == "block")
                    {

                        GameObject temp = Instantiate(block, Hit.point, Quaternion.identity);
                        surface.BuildNavMesh();
                    }

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

    IEnumerator bulletspread(float to, float from)
    {
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime * ADSSpeed)
        {
            bulletSpread = Mathf.Lerp(from, to, t);
            yield return null;

        }
    }
}
