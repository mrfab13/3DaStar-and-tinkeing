using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class trailmanager : MonoBehaviour
{
    public float timer = 0.0f;

    void Update()
    {
        timer += Time.deltaTime;
        this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x - (20.0f * Time.deltaTime), this.gameObject.transform.position.y, this.gameObject.transform.position.z);

        this.gameObject.transform.GetChild(0).GetChild(0).GetComponent<Image>().color =  (Vector4.Lerp(new Vector4(1.0f, 1.0f, 0.0f, 1.0f), new Vector4(0.5f, 0.5f, 0.5f, 0.0f), timer / 5.0f));

        if (timer >= 5.0f)
        {
            Destroy(this.gameObject);
        }
    }
}
