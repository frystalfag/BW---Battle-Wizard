using UnityEngine;

public interface ISkeletStates
{
    void Idle();
    void Patrol();
    void Chase();
    void Attack();
    void Die();
}
