using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public float timeBetweenWaves = 5f;
    public int MaxEnemyCount = 5; // 최대 적 수
    public Vector3 _poolPosition = new Vector3(100, 100, 100);


    private List<EnemyMove> _enemies = new List<EnemyMove>(); // enemy 위치를 담을 곳.
    //private GameObject[] _enemies; // enemy 위치를 담을 곳.
    private float countDown = 2f;
    private int waveIndex = 1;
    private float _coolTime;

    [SerializeField]
    private int MaxWave =10 ;

    //void Start()
    //{

    //    _enemies = new GameObject[MaxEnemyCount];
    //    for(int i = 0; i < MaxEnemyCount; ++i)
    //    {
    //        _enemies[i] = Instantiate(enemyPrefab, _poolPosition, Quaternion.identity);
    //    }
    //    _coolTime = 0;

    //}

    private void Start()
    {
        StartCoroutine(SpawnWave());
    }
    /*void Update()
    {
        if (countDown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countDown = timeBetweenWaves;
        }
        countDown -= Time.deltaTime / 2;
    }*/

    IEnumerator SpawnWave()
    {
       
        for (int i = 0; i < MaxWave; i++)
        {
            SpawnEnemy();
            
            yield return new WaitForSeconds(5f);
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        waveIndex++;
    }
}

