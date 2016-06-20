using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour
{
    void Start()
    {
        NumberRandom.ToolSet obj = new NumberRandom.ToolSet();
        print("The random number is: "+ obj.GetRandomNum());
    }


}
