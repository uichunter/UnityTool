using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPooling : MonoBehaviour {

    public static ObjectPooling m_Current;
    public GameObject m_PooledObject;
    public int m_PoolAmount = 20;
    public bool m_WillGrow = true;
    //public int m_PoolAmountMax; TODO: The pool need a roof to prevent 

    List<GameObject> m_PoolObjectList;

    void Awake(){
        m_Current = this;
    }

	// Use this for initialization
	void Start () {
        m_PoolObjectList = new List<GameObject>();
        for (int i = 0;i<m_PoolAmount;i++) {
            GameObject pooledObj = Instantiate(m_PooledObject) as GameObject;
            pooledObj.SetActive(false);
            m_PoolObjectList.Add(pooledObj);
        }
	}

    public GameObject GetPooledObj() {
        for (int i = 0; i < m_PoolObjectList.Count; i++) {
            if (!m_PoolObjectList[i].activeInHierarchy) {
                return m_PoolObjectList[i];
            }
        }

        if (m_WillGrow) {
            GameObject pooledObj = Instantiate(m_PooledObject) as GameObject;
            m_PoolObjectList.Add(pooledObj);
            return pooledObj;
        }

        return null;
    }
}
