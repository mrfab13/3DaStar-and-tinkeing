using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missile : MonoBehaviour
{
    public Vector3 start;
    public Vector3 skyTarget;
    public Vector3 target;
    public LayerMask enemy;


    private Vector3 direction;
    private Quaternion lookrotation;

    void Start()
    {
        start = this.transform.position;
        direction = (target - skyTarget).normalized;
        lookrotation = Quaternion.LookRotation(direction);
        lookrotation *= Quaternion.Euler(90, 0, 0);
        StartCoroutine(up());
    }

    IEnumerator up()
    {
        yield return new WaitForSeconds(1.0f);

        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime)
        {
            this.transform.position = new Vector3(Mathf.Lerp(start.x, skyTarget.x, t), Mathf.Lerp(start.y, skyTarget.y, t), Mathf.Lerp(start.z, skyTarget.z, t));
            this.gameObject.transform.rotation = Quaternion.Slerp(Quaternion.identity, lookrotation, t);
            yield return null;
        }
        StartCoroutine(shoot());
    }

    IEnumerator shoot()
    {
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime)
        {
            this.transform.position = new Vector3(Mathf.Lerp(skyTarget.x, target.x, t), Mathf.Lerp(skyTarget.y, target.y, t), Mathf.Lerp(skyTarget.z, target.z, t));
            yield return null;
        }

        Collider[] colliders = Physics.OverlapSphere(transform.position, 7.0f, enemy);


        if (colliders.Length > 0)
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                colliders[i].gameObject.GetComponent<enemy>().hp -= 50.0f;
            }

        }

        this.gameObject.transform.GetChild(0).GetComponent<SkinnedMeshRenderer>().enabled = false;
    }
}
