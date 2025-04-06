using System.Collections.Generic;
using UnityEngine;

public class SpellFactory
{
    public static void CreateSpell(SpellType spellType, Dictionary<SpellType, GameObject> SpellDictionary)
    {
        GameObject SpellPrefab = Help.GetPrefab(spellType, SpellDictionary);
        GameObject SpellObj = Object.Instantiate(SpellPrefab);
        
         
    }
}
