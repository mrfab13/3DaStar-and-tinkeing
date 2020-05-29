using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using pathfind;

public class plugindemo : MonoBehaviour
{
    //refrences
    private window editwindow;
    private iamryan iar;

    //destinations
    public List<GameObject> destinaitons;
    public int currdestination;


    void Start()
    {
        //set refrences and initlise
        currdestination = 0;
        iar = this.gameObject.GetComponent<iamryan>();
        editwindow = iar.editwindow;
        iar.whenFin = whenfinished();

        StartCoroutine(whenfinished());
    }


    //custom ienum that gets called from other script when the source reaches the destination
    public IEnumerator whenfinished()
    {
        Debug.Log("hi");

        //allows the script to reinitlise the direction the drone was traveling in 
        Path.currenttdirinit = true;

        //alternates between 2 destinations
        if (currdestination == 0)
        {
            currdestination = 1;
        }
        else if (currdestination == 1)
        {
            currdestination = 0;
        }

        //update and move again
        editwindow.destination = destinaitons[currdestination];
        iar.whenFin = whenfinished();

        iar.recalculate();
        iar.movment = true;


        yield return null;
    }
}
