using System;
using UnityEngine;

public class SPAwnmanger : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int enemyCount;
    private float spawnrange = 9;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnEnemyWave(3);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindFirstObjectByType<Enemy>().Length;
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
