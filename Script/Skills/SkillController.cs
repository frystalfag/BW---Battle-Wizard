using System;
using System.Collections.Generic;
using UnityEngine;

public enum SpellType
{
    FireTornado, FireBall, FireSword
}

[Serializable] public class SpellPrefabs
{
    public GameObject Prefab;
    public SpellType Type;
}
public class SkillController : MonoBehaviour
{
    [SerializeField] public List<SpellPrefabs> Skills = new List<SpellPrefabs>();
    public Dictionary<SpellType, GameObject> SkillDictionary = new Dictionary<SpellType, GameObject>();
    
    [SerializeField] private LayerMask groundLayer;
    
    private Transform PlayerTransform;
    public ManaBar _manaBar;
    public float curMana;

    void Awake()
    {
        foreach (var i in Skills)
        {
            if (SkillDictionary.ContainsKey(i.Type))
            {
                Debug.LogError(i.Type + " is already in SkillDictionary");
            }
            else
            {
                SkillDictionary.Add(i.Type, i.Prefab);
            }
        }
    }
    
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
                _manaBar.UseMana(FireTornado.manaCost);
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out RaycastHit hit, 15f, groundLayer))
                {
                    Vector3 point = hit.point;
                    SpellFactory.CreateSpell(SpellType.FireTornado, SkillDictionary, point);
                }

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
                //SpellFactory.CreateSpell("FireBall");
                _manaBar.UseMana(Slow.manaCost);
            }
            else
            {
                Debug.Log("Mana missing.");
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (curMana >= Slow.manaCost)
            {
                //SpellFactory.CreateSpell("FireSword");
                _manaBar.UseMana(Slow.manaCost);
            }
            else
            {
                Debug.Log("Mana missing.");
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Debug.Log(4);
        }
    }

    public GameObject GetPrefab(SpellType types)
    {
        if (SkillDictionary.TryGetValue(types, out GameObject prefab))
        {
            return prefab;
        }
        else
        {
            Debug.LogError($"Spell prefab {types} not found");
            return null;    
        }
    }
}
