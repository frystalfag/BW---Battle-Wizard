using UnityEngine;

public class SpellFactory
{
    public static Spell CreateSpell(string spellType)
    {
        switch (spellType)
        {
            case "FireTornado": 
                return new FireTornado();
            case "Slow": 
                return new Slow();
            default:
                Debug.LogError("No spell type");
                return null; 
        }
    }    
}
