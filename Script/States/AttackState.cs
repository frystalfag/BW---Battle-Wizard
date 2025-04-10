using UnityEngine;
using UnityEngine.TextCore.Text;

public class AttackState : IState
{
    private CharacterContext _characterContext;

    public AttackState(CharacterContext characterContext)
    {
        this._characterContext = characterContext;
    }

    public void Enter()
    {
        _characterContext.animator.SetTrigger("Attack");    
    }

    public void Exit()
    {
        _characterContext.animator.ResetTrigger("Attack");
    }

    public void Update()
    {
        if (_characterContext.IsFinished("Attack"))
        {
            _characterContext.ChangeState(new IdleState(_characterContext));
        }
    }
}
