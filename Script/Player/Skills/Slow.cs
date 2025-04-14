using UnityEngine;

public class Slow : Spell
{
    public float NewSpeed = 0.5f;
    public float Duration = 5f;
    public static float manaCost = 20f;

    public override void CastSpell()
    {
        Debug.Log("Slow");
        EnemyController enemy = FindObjectOfType<EnemyController>();
        if (enemy != null)
        {
            enemy.ApplyPassiveEffect(new SlowEffect(NewSpeed, Duration));
        }
    }
}
