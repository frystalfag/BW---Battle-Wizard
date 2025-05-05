using UnityEngine;
using UnityEngine.TextCore.Text;

public class RunState : IState
{
    private CharacterContext _characterContext;

    public RunState(CharacterContext character)
    {
        this._characterContext = character;
    }

    public void Enter()
    {
        _characterContext.animator.SetTrigger("Run");
    }

    public void Exit()
    { 
        _characterContext.animator.ResetTrigger("Run");
    }

    public void Update()
    {
        if (_characterContext.IsFinished("Run"))
        {
            _characterContext.ChangeState(new IdleState(_characterContext));
        }
    }
}