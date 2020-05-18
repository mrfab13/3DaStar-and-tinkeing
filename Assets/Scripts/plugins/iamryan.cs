using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using pathfind;

public class iamryan : MonoBehaviour
{
    public GameObject boxes;
    public GameObject nodePrefab;
    public float deets;
    public GameObject source;
    public bool reclaculatepath;
    public bool movment = false;
    public float movespeed;

    private void Start()
    {
        Path.nodeprefab = nodePrefab;
        Path.thebox = boxes;
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
        reclaculatepath = false;

        Path.CalculatePath();

        redrawnodes();
    }


    void OnDrawGizmos()
    {
        for (int i = 0; i < Path.pathlist.Count; i++)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawCube(Path.pathlist[i].returnpos(), new Vector3((Path.detail / 4.0f), (Path.detail / 4.0f), (Path.detail / 4.0f)));
        }
    }
}
