using UnityEngine;
using UnityEngine.AI;

public class MovementState : IState
{
    public Animator animator;
    public CharacterContext characterContext;
    private float movementSpeed;

    public MovementState(Animator animator, float speed, CharacterContext characterContext)
    {
        this.movementSpeed = speed;
        this.animator = animator;
        this.characterContext = characterContext;
    }

    

    public void Enter() {}
    public void Exit() {}
    
    public void Update()
    {
        animator.SetFloat("Speed", movementSpeed);
    }
}
