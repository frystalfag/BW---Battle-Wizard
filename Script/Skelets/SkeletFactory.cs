using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Object;

public class SkeletFactory
{
    public static Skelet CreateSkelet(SkeletType SkeletType, int level, Spawner spawner, float damage, float attackDis, float radius, Dictionary<SkeletType, GameObject> SkeletDictionary)
    {
        GameObject SkeletPrefab = Help.GetPrefab(SkeletType, SkeletDictionary);
        GameObject SkeletObj = Object.Instantiate(SkeletPrefab);
        Skelet skelet = SkeletObj.GetComponent<Skelet>();
        
        skelet.Initialize(spawner, level, damage, attackDis, radius);
        return skelet;
    } 
}
