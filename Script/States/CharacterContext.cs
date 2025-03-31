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
}
