using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnObjectsController : MonoBehaviour
{
    [Serializable]
    public struct TypePrefab
    {
        [SerializeField] public SpawnType Type;
        [SerializeField] public GameObject ObjectToSpawn;
    }

    [Serializable]
    public struct TypeName
    {
        [SerializeField] public SpawnType Type;
        [SerializeField] public string Name;
    }


    [SerializeField] private List<TypePrefab> _prefabs = default;
    [SerializeField] private List<TypeName> _names = default;
    private SpawnType _type = default;


    public GameObject Spawn(Vector3 spawnPosition)
    {
        GameObject spawnablePrefab = _prefabs.First(x => x.Type == _type).ObjectToSpawn;
        GameObject spawnedObject = Instantiate(spawnablePrefab, spawnPosition, Quaternion.identity);
        return spawnedObject;
    }

    public void AddTypeCounter(int addIndex)
    {
        int length = Enum.GetNames(typeof(SpawnType)).Length;
        _type = (SpawnType)(((int)_type + addIndex) % length);
    }

    public string GetSpawnableObjectName()
    {
        return _names.First(x => x.Type == _type).Name;
    }
}