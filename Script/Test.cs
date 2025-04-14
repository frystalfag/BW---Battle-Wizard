using UnityEngine;

public class Test : MonoBehaviour
{
    void Start()
    {
        /*Skelet Mage = SkeletFactory.CreateSkelet("Mage");
        Skelet Warrior = SkeletFactory.CreateSkelet("Warrior");
        Skelet Warrior2 = SkeletFactory.CreateSkelet("Warrior2");
        Skelet Archer = SkeletFactory.CreateSkelet("Archer");*/
        
        /*Spell FireTornado = SpellFactory.CreateSpell("FireTornado");
        Spell Slow = SpellFactory.CreateSpell("Slow");*/
        
        /*FireTornado.CastSpell();
        Slow.CastSpell();*/
        
        /*Warrior2.Atack();
        Mage.Atack();
        Warrior.Atack();
        Archer.Atack();
        
        Mage.Move();
        Warrior.Move();
        Warrior2.Move();
        Archer.Move();*/

        /*string a = TestMethod<string>("Hello");
        int b = TestMethod<int>(10);
        
        Transform n = GetComponent<Transform>();
        TestMethod("Test")*/;
        float x;
        if (TryDivide(10, 2, out x))
        {
            Debug.Log(x);
        }

    }
    
    /*public T TestMethod<T>(T value)
    {
        return value;        
    }*/

    public bool TryDivide(int a, int b, out float result)
    {
        if (b == 0)
        {
            result = 0;
            return false;
        }
        result = (float)a / b;
        return true;
    }
    
    
    
}
