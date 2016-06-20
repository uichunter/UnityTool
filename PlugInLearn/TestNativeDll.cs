using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class TestNativeDll : MonoBehaviour {

	void Start () {
        print("Native random number: " +PlugInWrapper.GetRanNum());
	}
}
