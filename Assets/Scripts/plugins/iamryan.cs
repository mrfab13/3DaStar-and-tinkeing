using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using pathfind;
using UnityEditor;

public class iamryan : MonoBehaviour
{
    [HideInInspector]
    public bool reclaculatepath = false;
    [HideInInspector]
    public bool movment = false;
    [HideInInspector]
    public bool movfinished = false;
    private bool movfin1call = false;
    private bool movfinishedonce = false;

    [HideInInspector]
    public window editwindow;

    [HideInInspector]
    public GameObject destination;
    [HideInInspector]
    public GameObject returnto;
    [HideInInspector]
    public IEnumerator whenFin;

    void Awake()
    {
        editwindow = (window)EditorWindow.GetWindow(typeof(window));
    }

    void Update()
    {
        movfinished = Path.endofmovereached;

        if (movfinished == true)
        {
            //while stopped

            movfin1call = false;

            if (movfinishedonce == true)
            {
                movfinishedonce = false;
                movfin1call = true;
            }
        }
        else
        {
            if (movfinishedonce == false)
            {
                movfinishedonce = true;
                movfin1call = false;
            }
        }

        //once when finished
        if (movfin1call == true)
        {
            movfin1call = false;
            if (whenFin != null)
            {
                StartCoroutine(whenFin);
            }
        }


        if (Path.iamryanrecalc == true)
        {
            reclaculatepath = true;
        }

        if (reclaculatepath == true)
        {
            recalculate();
        }

        if (movment == true)
        {
            Path.smoothDisable = !editwindow.groupEnabled;
            Path.directionmovespeed = editwindow.rateofAnglechange;
            Path.movespeed = editwindow.movespeed;
            Path.movement();
        }

    }

    public void recalculate()
    {
        Path.recalctimer = editwindow.recalcwhenidle;
        Path.startphysical = editwindow.source;
        Path.finishphysical = editwindow.destination;
        Path.stopnextto = editwindow.stopnextto;
        Path.recalculateEachStep = editwindow.recalc;
        Path.BBbounds = editwindow.testbounds;
        Path.BBbounds.extents = new Vector3((Path.BBbounds.extents.x / 2.0f), (Path.BBbounds.extents.y / 2.0f), (Path.BBbounds.extents.z / 2.0f));
        Path.detail = editwindow.deets;

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
