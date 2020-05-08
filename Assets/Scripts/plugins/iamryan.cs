using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using pathfind;

public class iamryan : MonoBehaviour
{
    public List<GameObject> boxes = new List<GameObject>() { };
    public GameObject nodePrefab;
    public float deets;
    public GameObject source;
    public bool reclaculatepath;
    public bool movment = false;
    public float movespeed;

    private void Start()
    {
        Path.nodeprefab = nodePrefab;
        for (int i = 0; i < boxes.Count; i++)
        {
            Path.boxes.Add(boxes[i]);
        }
        Path.source = source;
    }


    private void Update()
    {
        if (reclaculatepath == true)
        {
            recalculate();
        }

        if (movment == true)
        {
            Path.movespeed = movespeed;
            Path.movement();
        }
    }

    public void redrawnodes()
    {


        GameObject[] count = GameObject.FindGameObjectsWithTag("node");

        for (int i = count.Length; i > 0; i--)
        {
            Destroy(count[i - 1]);
        }

        Path.drawNodes();
    }

    public void recalculate()
    {
        
        Path.detail = deets;

        Path.CalculatePath();
        reclaculatepath = false;

        redrawnodes();
    }
}
