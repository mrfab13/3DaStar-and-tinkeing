using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using pathfind;


public class plugindemo : MonoBehaviour
{
    private window editwindow;
    private iamryan iar;

    public bool startmov = false;

    public List<GameObject> destinaitons;
    public int currdestination = 0;


    void Start()
    {
        iar = this.gameObject.GetComponent<iamryan>();
        editwindow = iar.editwindow;
        iar.whenFin = whenfinished();


        iar.recalculate();
    }

    void Update()
    {
        if (startmov == true)
        {
            iar.reclaculatepath = true;
            iar.movment = true;
        }
    }

    public IEnumerator whenfinished()
    {
        Path.currenttdirinit = true;

        yield return new WaitForSeconds(3.0f);

        editwindow.destination = destinaitons[currdestination];

        yield return null;
    }
}
