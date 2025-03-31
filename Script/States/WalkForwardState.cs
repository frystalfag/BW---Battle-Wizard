using UnityEngine;
using UnityEngine.AI;

public class WalkForwardState : MonoBehaviour
{
    public Animator animator;

    public WalkForwardState(Animator animator)
    {
        this.animator = animator;
    }

    public void Enter()
    {
        animator.SetTrigger("WalkingForward");
    }

    public void Exit()
    {
        animator.ResetTrigger("WalkingForward");
    }

    public void Update()
    {
    }
}
