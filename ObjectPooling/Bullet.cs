using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    Rigidbody2D m_Rigidbody2D;
    public float m_BulletSpeed = 2;
    public float m_BulletLiveTime = 3f;

    void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void OnEnable() {
        Invoke("Destroy",m_BulletLiveTime);
        m_Rigidbody2D.velocity = new Vector2(0, m_BulletSpeed);
    }

    void Destroy() {
        gameObject.SetActive(false);
    }

    void OnDisable() {
        CancelInvoke();
    }

}
