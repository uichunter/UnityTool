using UnityEngine;
using System.Collections;

public class StatePatternEnemy : MonoBehaviour
{
    public float m_SearchingTurnSpeed = 120f;
    public float m_SearchingDuration = 4f;
    public float sightRange = 20f;
    public float m_ColorChangeTIme = 1f;
    public Transform[] m_WayPoints;
    public Transform m_Eye;
    public Vector3 m_Offset = new Vector3(0,0.5f,0);
    public MeshRenderer m_MeshRendererFlag;

    [HideInInspector]public Transform m_ChaseTarget;
    [HideInInspector]public IEnemyState m_CurrentState;
    [HideInInspector]public AlertState m_AlertState;
    [HideInInspector]public ChaseState m_ChaseState;
    [HideInInspector]public PatrolState m_PatrolState;
    [HideInInspector]public NavMeshAgent m_NavMeshAgent;

    void Awake()
    {
        m_ChaseState = new ChaseState(this);
        m_AlertState = new AlertState(this);
        m_PatrolState = new PatrolState(this);

        m_NavMeshAgent = GetComponent<NavMeshAgent>();
    }


    // Use this for initialization
    void Start ()
    {
        m_CurrentState = m_PatrolState;
	}
	
	// Update is called once per frame
	void Update ()
    {
        m_CurrentState.UpdateState();
	}

    private void OnTriggerEnter(Collider obj)
    {
        m_CurrentState.OnTriggerEnter(obj);
    }
}
