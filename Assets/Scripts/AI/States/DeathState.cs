using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState : BaseState
{
    private float deathTimeAnim = 3.2f;
    private float timer;

    private Animator animator;
    private MobStateSO stats;

    public DeathState(MobStateMachine states, MobStateSO statsSO)
    {
        stateMachine = states;
        animator = stateMachine.GetComponent<Animator>();
        stats = statsSO;
    }

    public override void Enter()
    {
        animator.SetTrigger("Death");
    }

    public override void Exit()
    {
        // Этот метод пустой в предоставленном коде
    }

    public override void LogicUpdate()
    {
        timer += Time.deltaTime;
        if (timer >= deathTimeAnim)
        {
            MonoBehaviour.Destroy(stateMachine.gameObject);
        }
    }
}
