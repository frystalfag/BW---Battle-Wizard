using System.Collections.Generic;
using UnityEngine;

public static class Help
{
    public static GameObject GetPrefab<T>(T types, Dictionary<T, GameObject> prefabs)
    {
        if (prefabs.TryGetValue(types, out GameObject obj))
        {
            return obj;    
        }
        else
        {
            Debug.LogError($"Prefab {types} not found");
            return null;
        }
    }
}
