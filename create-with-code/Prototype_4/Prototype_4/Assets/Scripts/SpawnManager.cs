using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject powerupPrefab;
    public int waveNumber = 1;
    private int enemiesToSpawnIn = 3;
    public int enemyCount;
    public GameObject enemyPrefab;
    private float spawnRange = 9;
    // Start is called before the first frame update
    void Start()
    {
        /* Make Powerup */
        spawnPowerUpWave(1);
        SpawnEnemyWave(waveNumber);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            spawnPowerUpWave(waveNumber);
        }
    }

    /* Function to generate a random spawn point */
    private Vector3 GenerateSpawnPosition () 
    {
        float spawnPosx = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosx, 0, spawnPosZ);

        return randomPos;
    }

    /* Spawn multiple enemies */
    void SpawnEnemyWave(int enemiesToSpawn) 
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    /* This will spawn a Powerup with every new wave */
    void spawnPowerUpWave(int powerupToSpawn)
    {
        for (int i = 0; i <= powerupToSpawn; i++)
        {
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        }
    }
}
