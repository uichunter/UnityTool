using UnityEngine;
using UnityEngine.Events;
using System.Collections;


public class Test1 : MonoBehaviour {
    private UnityAction m_Listener;

    void Awake() {
        m_Listener = new UnityAction(Ping) ;
    }

    void OnEnable() {
        EventManager.StartListening("test",m_Listener);
    }

    void OnDisable() {
        EventManager.StopListening("test",m_Listener);
    }


    void Ping() {
        Debug.Log("Ping!");
    }
}
