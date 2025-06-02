using System;
using UnityEngine;

public class SPAwnmanger : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int enemyCount;
    private float spawnrange = 9;
    public int waveNumber = 1;
    public GameObject poweruprefabs;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        Instantiate(poweruprefabs, GenerateSpawnPosition(), poweruprefabs.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsByType<Enemy>(FindObjectsSortMode.InstanceID).Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate(poweruprefabs, GenerateSpawnPosition(), poweruprefabs.transform.rotation);
        }
    }

    void SpawnEnemyWave(int EnemiesToSpawn)
    {
        for (int i = 0; i < EnemiesToSpawn; i++)

            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
    }

     private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = UnityEngine.Random.Range(-spawnrange, spawnrange);
        float spawnPosZ = UnityEngine.Random.Range(-spawnrange, spawnrange);


        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);


        return randomPos;
    }



}
