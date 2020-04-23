using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using System.IO;

public static class dlltest
{
    [DllImport("test2", EntryPoint = "TestDivide")]
    public static extern float divide(float a, float b);

    [DllImport("test2", EntryPoint = "TestMultiply")]
    public static extern float mult(float a, float b);


}
