using UnityEngine;

public interface IPassiveEffect 
{
    void ApplyEffect(EnemyController enemy);
    void RemoveEffect(EnemyController enemy);
}
