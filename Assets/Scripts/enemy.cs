using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemy : MonoBehaviour
{
    public float max = 100.0f;
    public float hp = 100.0f;

    void Update()
    {
        gameObject.transform.GetChild(0).GetChild(0).GetComponent<Image>().fillAmount = hp / max;

        if (hp <= 0.0f)
        {
            Destroy(this.gameObject);
        }
    }


}
