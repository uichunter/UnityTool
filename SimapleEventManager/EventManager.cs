using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class EventManager : MonoBehaviour {
    private Dictionary<string, UnityEvent> m_EventDictionary;

    private static EventManager m_EventManager;

    public static EventManager m_Instance
    { 
        get
        {
            if(!m_EventManager)
            {
                m_EventManager = FindObjectOfType(typeof(EventManager)) as EventManager;
                if (!m_EventManager)
                {
                    Debug.LogError("No event manager!");
                }
                else
                {
                    //Initialize eventmanager
                    m_EventManager.Init();
                }
            }
            return m_EventManager;
        }
    }

    void Init() {
        if (m_EventDictionary == null) {
            m_EventDictionary = new Dictionary<string, UnityEvent>();
        }
    }

    public static void StartListening(string eventName,UnityAction listener) {
        UnityEvent thisEvent = null;
        if (m_Instance.m_EventDictionary.TryGetValue(eventName,out thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener);
            m_Instance.m_EventDictionary.Add(eventName,thisEvent);
        }
    }

    public static void StopListening(string eventName,UnityAction listener)
    {
        if (m_EventManager == null) return;

        UnityEvent thisEvent = null;

        if (m_Instance.m_EventDictionary.TryGetValue(eventName,out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }

    public static void TriggerEnvet(string eventName) {
        UnityEvent thisEvent = null;
        if (m_Instance.m_EventDictionary.TryGetValue(eventName,out thisEvent)) {
            thisEvent.Invoke();
        }
    }
}
