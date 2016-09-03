using UnityEngine;
using System.Collections;

public class AlertState : IEnemyState
{
    private readonly StatePatternEnemy m_Enemy;
    private float searchTime;

    public AlertState(StatePatternEnemy enemy)
    {
        m_Enemy = enemy;
    }

    public void UpdateState()
    {
        Look();
        Search();
    }

    public void OnTriggerEnter(Collider other)
    {

    }

    public void ToPatrolState()
    {
        m_Enemy.m_CurrentState = m_Enemy.m_PatrolState;
        searchTime = 0f;
    }

    public void ToAlertState()
    {
        Debug.LogError("Cant get same state.");
    }

    public void ToChaseState()
    {
        m_Enemy.m_CurrentState = m_Enemy.m_ChaseState;
        searchTime = 0f;
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

    private void Search()
    {
        Color thisColor = m_Enemy.m_MeshRendererFlag.material.color;
        m_Enemy.m_MeshRendererFlag.material.color = Color.Lerp(thisColor,Color.yellow,m_Enemy.m_ColorChangeTIme * Time.deltaTime);

        m_Enemy.m_NavMeshAgent.Stop();
        m_Enemy.transform.Rotate(0,m_Enemy.m_SearchingTurnSpeed * Time.deltaTime,0);
        searchTime += Time.deltaTime;

        if (searchTime >= m_Enemy.m_SearchingDuration) ToPatrolState();

    }
}
