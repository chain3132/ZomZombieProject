using UnityEngine;

public class WaveController : MonoBehaviour
{
    public Transform[] spawnPoints;

    private Wave currentWave;
    private int enemiesSpawned = 0;
    private float nextSpawnTime = 0f;

    public bool IsComplete()
    {
        return enemiesSpawned >= currentWave?.enemyCount;
    }

    public void StartWave(Wave wave)
    {
        currentWave = wave;
        enemiesSpawned = 0;
        nextSpawnTime = Time.time;
    }

    void Update()
    {
        if (currentWave == null) return;

        if (enemiesSpawned < currentWave.enemyCount && Time.time >= nextSpawnTime)
        {
            SpawnEnemy();
            enemiesSpawned++;
            nextSpawnTime = Time.time + currentWave.spawnInterval;
        }
    }

    void SpawnEnemy()
    {
        int tagIndex = Random.Range(0, currentWave.enemyTags.Length);
        int spawnIndex = Random.Range(0, spawnPoints.Length);

        enemyTags selectedTag = currentWave.enemyTags[tagIndex];
        Transform spawnPoint = spawnPoints[spawnIndex];

        GameObject enemy = EnemyObjectPool.Instance.SpawnFromPool(selectedTag, spawnPoint.position, spawnPoint.rotation);
    }
}
