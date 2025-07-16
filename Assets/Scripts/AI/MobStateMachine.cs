using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobStateMachine : MonoBehaviour
{
    public MobStateSO Stats => stats;
    [SerializeField] private MobStateSO stats;
    [SerializeField] private Transform player;
    public IdleState Idle => idle;
    private IdleState idle;
    private BaseState curState;
    public PatrolState Patrol => patrol;
    private PatrolState patrol;

    public FollowState Follow => follow;
    private FollowState follow;
    public AttackState Attack => attack;
    private AttackState attack;

    public DeathState Death => death;
    private DeathState death;

    // Start is called before the first frame update
    void Start()
    {
        idle = new IdleState(this, player, stats);
        patrol = new PatrolState(this, player, stats);
        follow = new FollowState(this, player, stats);
        attack = new AttackState(this, player, stats);
        death = new DeathState(this, stats);
        ChangeState(idle);
    }

    public void ChangeState(BaseState newState)
    {
        if (curState == death)
            return;
        Debug.Log("Old state: " + curState);
        if (curState != null)
            curState.Exit();
        curState = newState;
        curState.Enter();
        Debug.Log("New state: " + curState);
    }

    private void Update()
    {
        if (curState != null)
            curState.LogicUpdate();
    }
}
