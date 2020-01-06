using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EqupedWepon : MonoBehaviour
{
    public GameObject grad;
    public List<GameObject> icons;
    public List<float> ICON1topbot;
    public List<float> ICON2topbot;
    private RectTransform gradrect;
    private bool isrunning = false;

    private Vector2 start;
    private IEnumerator changed1;

    void Start()
    {
        gradrect = grad.GetComponent<RectTransform>();
    }

    public void fromto(wepon.wepons isequipped)
    {
        if (isrunning == true)
        {
            StopCoroutine(changed1);
        }

        if (isequipped == wepon.wepons.build)
        {
            changed1 = changed(ICON1topbot);
            icons[0].GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            icons[1].GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1.0f);
        }

        if (isequipped == wepon.wepons.missileLauncher)
        {
            changed1 = changed(ICON2topbot);
            icons[0].GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1.0f);
            icons[1].GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

        }
        start = new Vector2(-gradrect.offsetMax[1], gradrect.offsetMin[1]);
        StartCoroutine(changed1);
    }

    IEnumerator changed(List<float> isequipped)
    {
        isrunning = true;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime * 5.0f)
        {
            gradrect.SetTop(Mathf.Lerp(start[0], isequipped[0], t));
            gradrect.SetBottom(Mathf.Lerp(start[1], isequipped[1], t));
            yield return null;
        }
        isrunning = false;
    }
}
