using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stonks : MonoBehaviour
{

    public float money = 50.0f;
    public float maxmoney = 100.0f;
    public GameObject slider;


    void Update()
    {
        GameObject temp =  Instantiate(slider, this.gameObject.transform.position, Quaternion.identity, this.gameObject.transform);
        temp.GetComponent<Slider>().value = money / maxmoney;
    }

    public void chnagecash(float delta)
    {
        StartCoroutine(cashchange(delta));
    }

    IEnumerator cashchange(float delta)
    {

        float togive = delta;

        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime)
        {
            float paying = delta * Time.deltaTime;
            togive -= paying;
            money += paying;

            yield return null;
        }

        money += togive;
    }
}
