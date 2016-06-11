using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerFire : MonoBehaviour {
    public GameObject m_Gun;

	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space)) {
            Fire();
        }
	}

    void Fire() {
        GameObject obj = ObjectPooling.m_Current.GetPooledObj();

        if (obj == null) { return; }

        obj.transform.position = m_Gun.transform.position;
        obj.transform.rotation = m_Gun.transform.rotation;
        obj.SetActive(true);
    }
}
