using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGcolor : MonoBehaviour
{

    public Color Start;
    public Color Fin;
    public float oscillationTimer = 2.0f;

    private bool to = true;
    private float timer = 0.0f;

    void Update()
    {
        if (to == true)
        {
            timer += Time.deltaTime;
            if (timer >= oscillationTimer)
            {
                to = false;
            }
        }
        else 
        {
            timer -= Time.deltaTime;
            if (timer <= 0.0f)
            {
                to = true;
            }
        }

        this.gameObject.GetComponent<Image>().color = Color.Lerp(Start, Fin, timer / oscillationTimer);
    }
}
