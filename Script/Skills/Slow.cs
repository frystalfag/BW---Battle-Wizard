using UnityEngine;

public class Slow : Spell
{
    public float NewSpeed = 0.5f;
    public float Duration = 5f;
    public bool IsSlow = false;
    public static float manaCost = 20f;
    
    public void Slowdown()
    {
        Name = "slowdown";
        IsSlow = true;
        EnemyController.ChangeSpeed(NewSpeed);
            Invoke(nameof(RemoveSpeed), Duration);
    }

    void RemoveSpeed()
    {
        IsSlow = false;
        EnemyController.ChangeSpeed(NewSpeed);
    }

    public override void CastSpell()
    {
        Debug.Log("Slow");
        Slowdown();
    }
}
