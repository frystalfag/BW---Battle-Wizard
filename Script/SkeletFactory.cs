using UnityEngine;
using static UnityEngine.Object;

public class SkeletFactory
{
    public static Skelet CreateSkelet(SkeletType SkeletType, int level, Spawner spawner, float damage, float attackDis, float radius)
    {
        GameObject SkeletPrefab = spawner.GetPrefab(SkeletType);
        GameObject SkeletObj = Object.Instantiate(SkeletPrefab);
        Skelet skelet = SkeletObj.GetComponent<Skelet>();
        
        skelet.Initialize(spawner, level, damage, attackDis, radius);
        return skelet;
    } 
}
