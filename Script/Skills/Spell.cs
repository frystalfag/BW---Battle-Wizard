using UnityEngine;

public abstract class Spell : MonoBehaviour
{ 
    public string Name {get; protected set;}
    
    public abstract void CastSpell();
}
