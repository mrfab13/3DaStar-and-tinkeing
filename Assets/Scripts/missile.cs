using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missile : MonoBehaviour
{
    public Vector3 start;
    public Vector3 skyTarget;
    public GameObject TargetObj;
    public LayerMask enemy;
    public GameObject Explosion;

    private Vector3 direction;
    private Quaternion lookrotation;

    void Start()
    {
        start = this.transform.position;
        direction = (TargetObj.transform.position - skyTarget).normalized;
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
            this.transform.position = new Vector3(Mathf.Lerp(skyTarget.x, TargetObj.transform.position.x, t), Mathf.Lerp(skyTarget.y, TargetObj.transform.position.y, t), Mathf.Lerp(skyTarget.z, TargetObj.transform.position.z, t));
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
        this.gameObject.GetComponent<AudioSource>().Stop();
        Instantiate(Explosion, this.gameObject.transform.position, Quaternion.identity);

    }
}
