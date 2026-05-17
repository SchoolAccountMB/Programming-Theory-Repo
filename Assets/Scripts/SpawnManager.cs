using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] SpawnPrefabs;

    private float spawnDelay = 1.5f;
    private float spawnRate = 2.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnEnemy", spawnDelay, spawnRate);
    }

    private void SpawnEnemy()
    {
        int randI = Random.Range(0, SpawnPrefabs.Length);

        Instantiate(SpawnPrefabs[randI]);
    }
}
