using UnityEngine;
using UnityEngine.TextCore.Text;

public class IdleState : IState
{
    public CharacterContext character;

    public IdleState(CharacterContext character)
    {
        this.character = character;
    }

    public void Enter()
    {
        character.animator.SetTrigger("Idle");
    }

    public void Exit()
    { 
        character.animator.ResetTrigger("Idle");
    }

    public void Update()
    {
    }
}
