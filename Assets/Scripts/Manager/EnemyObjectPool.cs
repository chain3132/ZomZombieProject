using System.Collections.Generic;
using UnityEngine;

public class EnemyObjectPool : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public enemyTags tag;
        public GameObject prefab;
        public int size;
    }

    public List<Pool> pools;
    public Transform parentTransform;
    private Dictionary<enemyTags, Queue<GameObject>> poolDictionary;
    

    public static EnemyObjectPool Instance;

    private void Awake()
    {
        Instance = this;
        poolDictionary = new Dictionary<enemyTags, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab, parentTransform);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(enemyTags tag, Vector3 position, Quaternion rotation)
    {
        
        GameObject objectToSpawn = poolDictionary[tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }
}
