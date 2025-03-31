using System.Collections.Generic;
using UnityEngine;

public class SkillController : MonoBehaviour
{
    public List<Skill> Skills = new List<Skill>();
    private Transform PlayerTransform;
    public ManaBar _manaBar;
    public float curMana; 
    void Start()
    {
        _manaBar = GetComponent<ManaBar>();
    }

    void Update()
    {
        curMana = _manaBar.CurMana;
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (curMana >= FireTornado.manaCost)
            {
                SpellFactory.CreateSpell("FireTornado");
                _manaBar.UseMana(FireTornado.manaCost);
            }
            else
            {
                Debug.Log("Mana missing");
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (curMana >= Slow.manaCost)
            {
                SpellFactory.CreateSpell("Slow");
                _manaBar.UseMana(Slow.manaCost);
            }
            else
            {
                Debug.Log("Mana missing.");
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Debug.Log(4);
        }
    }
}
