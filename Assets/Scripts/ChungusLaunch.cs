using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChungusLaunch : MonoBehaviour
{
    public float fireate = 1.0f;
    public GameObject missile;
    public LayerMask enemy;

    private Vector3 skytarget;
    private float timer;

    void Start()
    {
        skytarget = new Vector3(this.transform.position.x, this.transform.position.y + 10.0f, this.transform.position.z);
    }

    void Update()
    {
        if (timer > 0.0f)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0.0f)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, 7.0f, enemy);


            if (colliders.Length > 0)
            {
                timer = fireate;
                GameObject temp = Instantiate(missile, this.transform.position, Quaternion.identity);
                temp.GetComponent<missile>().skyTarget = skytarget;
                temp.GetComponent<missile>().TargetObj = colliders[0].gameObject;
            }
        }

    }
}
