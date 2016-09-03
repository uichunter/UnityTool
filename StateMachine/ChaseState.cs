using UnityEngine;
using System.Collections;

public class ChaseState :IEnemyState
{
    private readonly StatePatternEnemy m_Enemy;

    public ChaseState(StatePatternEnemy enemy)
    {
        m_Enemy = enemy;
    }

    public void UpdateState()
    {
        Look();
        Chase();
    }

    public void OnTriggerEnter(Collider other)
    {

    }

    public void ToPatrolState()
    {
        m_Enemy.m_CurrentState = m_Enemy.m_PatrolState;
    }

    public void ToAlertState()
    {
        m_Enemy.m_CurrentState = m_Enemy.m_AlertState;
    }

    public void ToChaseState()
    {
        Debug.LogError("Cant get to same state.");
    }

    private void Look()
    {
        RaycastHit hit;
        Vector3 enemyToTarget = (m_Enemy.m_ChaseTarget.position + m_Enemy.m_Offset) - m_Enemy.m_Eye.transform.position;
        if (Physics.Raycast(m_Enemy.m_Eye.position, enemyToTarget, out hit, m_Enemy.sightRange) && hit.collider.CompareTag("Player"))
        {
            m_Enemy.m_ChaseTarget = hit.transform;
        }
        else
        {
            ToAlertState();
        }
    }

    private void Chase()
    {
        Color thisColor = m_Enemy.m_MeshRendererFlag.material.color;
        m_Enemy.m_MeshRendererFlag.material.color = Color.Lerp(thisColor,Color.red,m_Enemy.m_ColorChangeTIme*Time.deltaTime);

        m_Enemy.m_NavMeshAgent.destination = m_Enemy.m_ChaseTarget.position;
        m_Enemy.m_NavMeshAgent.Resume();

    }
}
