using System;
using System.Linq.Expressions;
using UnityEngine;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public enum SkeletType
{
    Warrior, Mage, Archer, Warrior2
}

[Serializable] public class SkeletPrefab
{
    public GameObject prefab;
    public SkeletType type;
    
}

public class Spawner : MonoBehaviour
{
    [SerializeField] public List<SkeletPrefab> SkeletPrefabs = new List<SkeletPrefab>();
    public Dictionary<SkeletType, GameObject> skelets = new Dictionary<SkeletType, GameObject>();
    private GameObject[] Mobs;
    
    [SerializeField] private List<SkeletType> types = new List<SkeletType>();
    public float RadiusToSpawn = 5;
    public float TimeToSpawn = 20;
    private float MaximumMobs = 10;
    
    private List<Skelet> MobsList = new List<Skelet>();
    private string[] MobTypes = {"Warrior", "Mage", "Warrior2", "Archer"};

    void Awake()
    {
        foreach (var i in SkeletPrefabs)
        {
            if (skelets.ContainsKey(i.type))
            {
                Debug.LogWarning($"Skelet prefab {i.type} already exists");
            }
            else
            {
                skelets.Add(i.type, i.prefab);
            }
        }
    }
    
    void Start()
    {
        InvokeRepeating("SpawnMob", TimeToSpawn, 20);
    }

    public GameObject GetPrefab(SkeletType types)
    {
        if (skelets.TryGetValue(types, out GameObject obj))
        {
            return obj;    
        }
        else
        {
            Debug.LogError($"Skelet prefab {types} not found");
            return null;
        }
    }

    void SpawnMob()
    {
        if (MobsList.Count >= MaximumMobs)
        {
            return;
        }
        else
        {
            int level = UnityEngine.Random.Range(0, MobTypes.Length);
            SkeletType MobType = types[Random.Range(0, MobTypes.Length)];
            Skelet Skelet = SkeletFactory.CreateSkelet(MobType, level, this, 10f, 10f, 10f);
            Vector3 spawnOffset = new Vector3(Random.insideUnitCircle.x, 0, Random.insideUnitCircle.y) * RadiusToSpawn;
            Vector3 spawnPos = transform.position + spawnOffset;

            GameObject SpawnedMob = Instantiate(Skelet.gameObject, spawnPos, Quaternion.identity);
            MobsList.Add(Skelet);
        }
    }

    public void DestroyMob(Skelet Skelet)
    {
        MobsList.Remove(Skelet);    
    }
}
