using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using System.IO;

public class dlltest : MonoBehaviour
{
    [DllImport("TEST1", EntryPoint = "TestDivide")]
    public static extern float StraightFromDllTestDivide(float a, float b);

    void Start()
    {
        float straightFromDllDivideResult = StraightFromDllTestDivide(20, 5);

        Debug.Log(straightFromDllDivideResult);

    }

}
