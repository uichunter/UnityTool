using UnityEngine;
using System.Collections;

public class EventTriggerTest : MonoBehaviour {

    public Test1 m_Test1;

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 200, 20), "Test Event Trigger"))
        {
            EventManager.TriggerEnvet("test");
        }

        if (GUI.Button(new Rect(10, 30, 200, 20), "Turn on/off Test1"))
        {
            m_Test1.gameObject.SetActive(!m_Test1.gameObject.activeSelf);
        }
    }
}
