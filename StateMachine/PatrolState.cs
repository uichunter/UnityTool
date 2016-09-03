using UnityEngine;
using System.Collections;

public class PatrolState : IEnemyState
{
    private readonly StatePatternEnemy m_Enemy;
    private int nextWayPoint;

    public PatrolState(StatePatternEnemy enemy)
    {
        m_Enemy = enemy;
    }

    public void UpdateState()
    {
        Look();
        Partrol();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) ToAlertState();
    }

    public void ToPatrolState()
    {
        Debug.LogError("Cant get the same state.");
    }

    public void ToAlertState()
    {
        m_Enemy.m_CurrentState = m_Enemy.m_AlertState;
    }

    public void ToChaseState()
    {
        m_Enemy.m_CurrentState = m_Enemy.m_ChaseState;
    }

    private void Look()
    {
        RaycastHit hit;
        if (Physics.Raycast(m_Enemy.m_Eye.position, m_Enemy.m_Eye.transform.forward, out hit, m_Enemy.sightRange) && hit.collider.CompareTag("Player"))
        {
            m_Enemy.m_ChaseTarget = hit.transform;
            ToChaseState();
        }
    }

    private void Partrol()
    {
        Color thisColor = m_Enemy.m_MeshRendererFlag.material.color;
        m_Enemy.m_MeshRendererFlag.material.color = Color.Lerp(thisColor, Color.green, m_Enemy.m_ColorChangeTIme * Time.deltaTime);

        m_Enemy.m_NavMeshAgent.destination = m_Enemy.m_WayPoints[nextWayPoint].position;

        m_Enemy.m_NavMeshAgent.Resume();

        if (m_Enemy.m_NavMeshAgent.remainingDistance <= m_Enemy.m_NavMeshAgent.stoppingDistance && !m_Enemy.m_NavMeshAgent.pathPending)
        {
            nextWayPoint = (nextWayPoint + 1) % m_Enemy.m_WayPoints.Length;
        }
    }
}
