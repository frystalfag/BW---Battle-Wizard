using System;
using UnityEngine;

public class CharacterContext : MonoBehaviour
{
    public Animator animator;
    private StateMachine stateMachine;
    private IState currentState;

    private void Awake()
    {
        stateMachine = new StateMachine();
    }

    public void ChangeState(IState newState)
    {
        if (currentState == newState) {return;}
        
        currentState?.Exit();
        currentState = newState;
        currentState?.Enter();
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

    private void Update()
    {
        currentState?.Update();
    }

    public IState GetCurrentState()
    {
        return currentState;
    }
    
    public void UpdateState()
    {
        if (currentState != null)
        {
            currentState.Update();
        }
    }
}
