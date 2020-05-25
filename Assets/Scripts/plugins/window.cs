using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Text.RegularExpressions;

public class window : EditorWindow
{
    public string stign = "im a text box for fun :D";
    public bool groupEnabled;
    public bool testbool = true;
    public float movespeed = 1.5f;
    public Bounds testbounds;
    public bool stopnextto = true;
    public bool recalc = false;
    public float recalcwhenidle = 1.5f;
    public GameObject source;
    public GameObject destination;
    public float deets = 2.0f;

    [MenuItem("Window/PathFinding")]
    static void init()
    {
        window tmp = (window)EditorWindow.GetWindow(typeof(window));
        tmp.Show();
    }

    void OnGUI()
    {
        GUILayout.Label("base settings", EditorStyles.boldLabel);
        stign = EditorGUILayout.TextField("text fild", stign);

        testbounds = EditorGUILayout.BoundsField("bounds box", testbounds);

        GUILayout.Label("if true it will stop next to the destination if false it will get as close as possible", EditorStyles.helpBox);
        stopnextto = EditorGUILayout.Toggle("stop next to", stopnextto);

        GUILayout.Label("recalculates each step, my be coputationaly intensive", EditorStyles.helpBox);
        recalc = EditorGUILayout.Toggle("recalc", recalc);

        movespeed = EditorGUILayout.FloatField("movespeed", movespeed);

        GUILayout.Label("how long between recalculates when source has already reached destination (set to 0 to disable)", EditorStyles.helpBox);
        recalcwhenidle = EditorGUILayout.FloatField("recalc timer", recalcwhenidle);

        source = (GameObject)EditorGUILayout.ObjectField("source object", source, typeof(GameObject), true);
        destination = (GameObject)EditorGUILayout.ObjectField("destination object", destination, typeof(GameObject), true);

        GUILayout.Label("how large the nodes are so bigger is less detailed, massive computational effect", EditorStyles.helpBox);
        deets = EditorGUILayout.FloatField("deets", deets);



        //groupEnabled = EditorGUILayout.BeginToggleGroup("optinL settigns", groupEnabled);
        //testbool = EditorGUILayout.Toggle("toggler", testbool);
        //EditorGUILayout.EndToggleGroup();
    }

}
