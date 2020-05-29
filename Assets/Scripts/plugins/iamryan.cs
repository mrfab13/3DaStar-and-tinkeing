using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using pathfind;
using UnityEditor;

public class iamryan : MonoBehaviour
{
    //variables 
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

    //awake for self initlisation, start initlisation is done by the user in their own script
    void Awake()
    {
        editwindow = (window)EditorWindow.GetWindow(typeof(window));
    }

    void Update()
    {
        //source finished moving
        movfinished = Path.endofmovereached;

        if (movfinished == true)
        {
            //movfin1call is false except for the first instance of movfinished == true

            movfin1call = false;

            if (movfinishedonce == true)
            {
                movfinishedonce = false;
                movfin1call = true;
            }
        }
        else
        {
            //reset the movfin1call calc

            if (movfinishedonce == false)
            {
                movfinishedonce = true;
                movfin1call = false;
            }
        }

        //true one time when finished
        if (movfin1call == true)
        {
            movfin1call = false;
            //corotine set by the user
            StartCoroutine(whenFin);
        }

        //recalcuate
        if (Path.iamryanrecalc == true)
        {
            reclaculatepath = true;
        }

        if (reclaculatepath == true)
        {
            reclaculatepath = false;
            recalculate();
        }


        //if the source should be moving 
        if (movment == true)
        {
            Path.smoothDisable = !editwindow.groupEnabled;
            Path.directionmovespeed = editwindow.rateofAnglechange;
            Path.movespeed = editwindow.movespeed;
            Path.movement();
        }

    }

    //initilise all of the things to be used from the window, despite being called recalculate it is also used for the initial calculation aswell
    public void recalculate()
    {
        Path.recalctimer = editwindow.recalcwhenidle;
        Path.startphysical = editwindow.source;
        Path.finishphysical = editwindow.destination;
        Path.stopnextto = editwindow.stopnextto;
        Path.recalculateEachStep = editwindow.recalc;

        if (editwindow.groupEnabled2 == false) //static bounds
        {
            Vector3 middlepos = editwindow.testbounds.center;
            Vector3 extents = editwindow.testbounds.extents;

            Path.BBbounds = new Bounds(middlepos, extents);
        }
        else // dyanmic bounds
        {
            Vector3 middlepos = ((editwindow.source.transform.position + editwindow.destination.transform.position) / 2.0f);
            Vector3 extents = (editwindow.destination.transform.position - editwindow.source.transform.position);
            extents = new Vector3(Mathf.Abs(extents.x) + editwindow.dynamicedgesize, Mathf.Abs(extents.y) + editwindow.dynamicedgesize, Mathf.Abs(extents.z) + editwindow.dynamicedgesize);
            Path.BBbounds = new Bounds(middlepos, extents);

            editwindow.testbounds = Path.BBbounds;
            editwindow.testbounds.extents *= 2.0f;
        }

        Path.detail = editwindow.deets;

        Path.CalculatePath();
    }


    //draws gizmoes when in editor mode
    void OnDrawGizmos()
    {
        //bounds
        if (editwindow == null)
        {
            editwindow = (window)EditorWindow.GetWindow(typeof(window));
        }
        Gizmos.DrawWireCube(editwindow.testbounds.center, editwindow.testbounds.extents);

        //walkable nodes
        for (int i = 0; i < Path.nodes.Count; i++)
        {
            if (Path.nodes[i].getwalkable())
            {
                Gizmos.color = Color.red;
                Gizmos.DrawCube(Path.nodes[i].returnpos(), new Vector3((Path.detail / 8.0f), (Path.detail / 8.0f), (Path.detail / 8.0f)));
            }
        }

        //path source is taking
        for (int i = 0; i < Path.pathlist.Count; i++)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawCube(Path.pathlist[i].returnpos(), new Vector3((Path.detail / 4.0f), (Path.detail / 4.0f), (Path.detail / 4.0f)));
        }
    }
}
