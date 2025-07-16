using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolState : BaseState
{
    private NavMeshAgent agent;
    private Vector3 defPos;
    private Vector3 targetPos;
    private Animator animator;
    private Transform target;
    private MobStateSO stats;

    public PatrolState(MobStateMachine states, Transform target, MobStateSO stats)
    {
        stateMachine = states;
        agent = stateMachine.GetComponent<NavMeshAgent>();
        animator = stateMachine.GetComponent<Animator>();
        defPos = stateMachine.transform.position;
        this.target = target;
        this.stats = stats;
    }

    public override void Enter()
    {
        animator.SetBool("walk", true);
        agent.isStopped = false;
        GeneratePatrolPoint();
    }

    private void GeneratePatrolPoint()
    {
        targetPos = defPos + new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
        agent.SetDestination(targetPos);
    }

    public override void Exit()
    {
        animator.SetBool("walk", false);
        agent.isStopped = true;
    }

    public override void LogicUpdate()
    {
        if (Vector3.Distance(stateMachine.transform.position, target.position) <= stats.FollowRange)
        {
            stateMachine.ChangeState(stateMachine.Follow);
            return;
        }
        if (Vector3.Distance(stateMachine.transform.position, targetPos) < 2)
        {
            stateMachine.ChangeState(stateMachine.Idle);
        }
    }
}