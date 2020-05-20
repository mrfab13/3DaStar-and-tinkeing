using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using pathfind;
using UnityEditor;

public class iamryan : MonoBehaviour
{
    public float deets;
    public GameObject source;
    public GameObject destination;

    public bool reclaculatepath;
    public bool movment = false;
    public float movespeed;

    private window editwindow;
    private void Start()
    {
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

    public void recalculate()
    {
        Path.startphysical = source.transform.position;
        Path.finishphysical = destination.transform.position;

        Path.BBbounds = editwindow.testbounds;
        Path.BBbounds.extents = new Vector3((Path.BBbounds.extents.x / 2.0f), (Path.BBbounds.extents.y / 2.0f), (Path.BBbounds.extents.z / 2.0f));
        Path.detail = deets;
        reclaculatepath = false;

        Path.CalculatePath();

    }


    void OnDrawGizmos()
    {
        if (editwindow == null)
        {
            editwindow = (window)EditorWindow.GetWindow(typeof(window));
        }
        Gizmos.DrawWireCube(editwindow.testbounds.center, editwindow.testbounds.extents);


        for (int i = 0; i < Path.nodes.Count; i++)
        {
            if (Path.nodes[i].getwalkable())
            {
                Gizmos.color = Color.red;
                Gizmos.DrawCube(Path.nodes[i].returnpos(), new Vector3((Path.detail / 8.0f), (Path.detail / 8.0f), (Path.detail / 8.0f)));
            }
        }

        for (int i = 0; i < Path.pathlist.Count; i++)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawCube(Path.pathlist[i].returnpos(), new Vector3((Path.detail / 4.0f), (Path.detail / 4.0f), (Path.detail / 4.0f)));
        }
    }
}
