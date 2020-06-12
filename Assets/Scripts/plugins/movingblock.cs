using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingblock : MonoBehaviour
{
    public List<Vector3> positions = new List<Vector3>() { };
    public int currentpos = 0;
    public int prevpos = 0;
    public float speed = 1.0f;

    private IEnumerator tmp;

    void Start()
    {
        tmp = mov();
        StartCoroutine(tmp);   
    }

    public IEnumerator mov()
    {
        currentpos += 1;
        if (currentpos >= positions.Count)
        {
            currentpos = 0;
        }

        prevpos = currentpos - 1;
        if (prevpos < 0)
        {
            prevpos = positions.Count - 1;
        }

        for (float i = 0; i < 1.0f; i += Time.deltaTime * speed)
        {
            this.gameObject.transform.position = Vector3.Lerp(positions[prevpos], positions[currentpos], i);
            yield return null;
        }

        tmp = mov();
        StartCoroutine(tmp);
        yield return null;
    }
}
