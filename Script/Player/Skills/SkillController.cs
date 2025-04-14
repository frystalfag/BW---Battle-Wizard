using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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
    
    public float fireTornadoManaCost = 30f;
    public float fireBallManaCost = 15f;
    public float fireSwordManaCost = 20f;
    
    private bool isCasting = false;
    private SpellType selectedSpell;
    
    private MouseController mouseController;
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
        mouseController = GetComponent<MouseController>();
        _manaBar = GetComponent<ManaBar>();
    }

    void Update()
    {
        curMana = _manaBar.CurMana;
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            PrepareCast(SpellType.FireTornado, fireTornadoManaCost);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            PrepareCast(SpellType.FireBall, fireBallManaCost);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            PrepareCast(SpellType.FireSword, fireSwordManaCost);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 15f, groundLayer))
            {
                SpellFactory.CreateSpell(selectedSpell, SkillDictionary, hit.point);
                UseManaFor(selectedSpell);
                mouseController.SetActive(false);
                isCasting = false;
            }
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

    public void PrepareCast(SpellType types, float manaCost)
    {
        if (curMana >= manaCost)
        {
            selectedSpell = types;
            isCasting = true;
            mouseController.SetActive(true);
        }
        else
        {
            Debug.LogError($"Mana {curMana} is too low to cast");
        }
    }

    private void UseManaFor(SpellType spell)
    {
        switch (spell)
        {
            case SpellType.FireTornado:
                curMana += fireTornadoManaCost;
                break;
            case SpellType.FireBall:
                curMana += fireBallManaCost;
                break;
            case SpellType.FireSword:   
                curMana += fireSwordManaCost;
                break;
        }
    }
}
