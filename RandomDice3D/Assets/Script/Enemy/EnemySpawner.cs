using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public Vector3 _poolPosition = new Vector3(100, 100, 100);

    private List<EnemyMove> _enemies = new List<EnemyMove>(); // enemy 위치를 담을 곳.
    private float _coolTime;

    [SerializeField]
    private int MaxWave = 10;

    private void Start()
    {
        StartCoroutine(SpawnWave());
    }

    IEnumerator SpawnWave()
    {
        for (int j = 0; j < 10; j++)
        {
            for (int i = 0; i < MaxWave; i++)
            {
                SpawnEnemy();

                yield return new WaitForSeconds(2f);
            }
        }
    }

    void NextWave()
    {
        SpawnWave();
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}

