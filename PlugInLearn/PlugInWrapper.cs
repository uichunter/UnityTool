using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class PlugInWrapper
{
#if UNITY_STANDALONE_WIN
    const string dll = "NumberRandomDll";
#elif UNITY_STANDALONE_OSX
    const string dll = "RandomNumberBONDLE"
#elif UNITY_IOS
    const stirng dll = "NumberRandomDll";
#else
    const string dll = "";
#endif 

    [DllImport(dll)]
    private static extern int GetRandom();

    public static int GetRanNum()
    {
    #if (UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS)
        return GetRandom();
    #else
        return -1;
    #endif
    }
}
