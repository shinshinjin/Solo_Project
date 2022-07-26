using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public float timeBetweenWaves = 5f;

    private List<EnemyMove> _enemies = new List<EnemyMove>(); // enemy 위치를 담을 곳.
    private float countDown = 2f;
    private int waveIndex = 1;

    void Update()
    {
        if (countDown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countDown = timeBetweenWaves;
        }
        countDown -= Time.deltaTime / 2;
    }

    IEnumerator SpawnWave()
    {
        waveIndex++;
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(5f);
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    //public EnemyMove GetRandomEnemy() // 위치를 받은곳을 랜덤 위치로 지정한다.
    //{
    //    int randomIndex = Random.Range(0, _enemies.Length);
    //    return _enemies[randomIndex];
    //}
}

