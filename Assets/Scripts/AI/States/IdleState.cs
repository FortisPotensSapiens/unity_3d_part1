using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseState
{
    private float curStayTime;
    private float timer;
    private Transform target;
    private MobStateSO stats;

    public IdleState(MobStateMachine mobStateMachine, Transform target, MobStateSO stats)
    {
        stateMachine = mobStateMachine;
        this.target = target;
        this.stats = stats;
    }

    public override void Enter()
    {
        curStayTime = Random.Range(stats.MaxStayTimeBorders.x, stats.MaxStayTimeBorders.y);
    }

    public override void Exit()
    {
        timer = 0f;
    }

    public override void LogicUpdate()
    {
        if (Vector3.Distance(stateMachine.transform.position, target.position) <= stats.FollowRange)
        {
            stateMachine.ChangeState(stateMachine.Follow);
            return;
        }
        if (timer < curStayTime)
        {
            timer += Time.deltaTime;
        }
        else
        {
            stateMachine.ChangeState(stateMachine.Patrol);
        }
    }
}
