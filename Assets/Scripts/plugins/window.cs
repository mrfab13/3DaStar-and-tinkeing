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
    public float testfloat = 1.5f;
    public Bounds testbounds;


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

        groupEnabled = EditorGUILayout.BeginToggleGroup("optinL settigns", groupEnabled);
        testbool = EditorGUILayout.Toggle("toggler", testbool);
        testfloat = EditorGUILayout.FloatField("zoop", testfloat);
        EditorGUILayout.EndToggleGroup();
    }

}
