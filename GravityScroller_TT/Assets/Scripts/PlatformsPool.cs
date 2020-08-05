using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlatformsPool : MonoBehaviour
{
    [SerializeField] private Platforms[] _prefabs;
    [SerializeField] private List<GameObject> _pool;
    
    void Start()
    {
        Init();
    }

    private void Init()
    {
        for (int i = 0; i < _prefabs.Length; i++)
        {
            GameObject platforms = Instantiate(_prefabs[i].gameObject, transform.position, quaternion.identity);
            platforms.gameObject.SetActive(false);
            _pool.Add(platforms);
        }
    }

    public GameObject GetPrefab()
    {
        GameObject obj = null;
        foreach (var prefab in _pool)
        {
            if (!prefab.activeSelf)
            {
                obj =  prefab;
                break;
            }
        }

        return obj;
    }

}
