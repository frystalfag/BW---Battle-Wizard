using System;
using UnityEngine;

public class CharacterContext : MonoBehaviour
{
    public Animator animator;
    public float AttackColdown;
    public float Speed;
    public float Health;
    private StateMachine stateMachine;

    private void Awake()
    {
        stateMachine = new StateMachine();
    }

    void Start()
    {
        stateMachine.ChangeState(new IdleState(this));
    }

    public bool IsFinished(string name)
    {
        AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo(0);
        return state.IsName(name) && state.normalizedTime >= 1f;
    }

    public void ChangeState(IState newState)
    {
        stateMachine.ChangeState(newState);
    }
}
