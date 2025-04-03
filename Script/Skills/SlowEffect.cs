using UnityEngine;
using System.Collections;

public class SlowEffect : IPassiveEffect
{
    private float newSpeed;
    private float duration;

    private EnemyController enemy;

    public SlowEffect(float newSpeed, float duration)
    {
        this.newSpeed = newSpeed;
        this.duration = duration;
    }

    public void ApplyEffect(EnemyController enemy)
    {
        this.enemy = enemy;
        enemy.ChangeSpeed(newSpeed);
        enemy.StartCoroutine(RemoveCooldown());
    }

    public IEnumerator RemoveCooldown()
    {
        yield return new WaitForSeconds(duration);
        RemoveEffect();
    }

    public void RemoveEffect()
    {
        enemy.ResetSpeed();
    }
}
