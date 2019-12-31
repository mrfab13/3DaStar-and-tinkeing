using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wepon : MonoBehaviour
{
    public float fireRate = 1.0f;
    public float timer = 0.0f;

    public Animator pew;

    void Update()
    {

        if (timer > 0.0f)
        {
            timer -= Time.deltaTime;
        }

        if (Input.GetButton("Fire1") == true)
        {
            Debug.Log("try");

            if (timer <= 0.0f)
            {
                StartCoroutine(shot());



                RaycastHit Hit;
                Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Hit);

                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward), Color.red, 1.0f);

                if (Hit.collider.gameObject.transform.tag == "enemy")
                {
                    Hit.collider.gameObject.GetComponent<enemy>().hp -= 25.0f;
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
