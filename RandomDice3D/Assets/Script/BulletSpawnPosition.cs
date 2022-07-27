using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawnPosition : MonoBehaviour
{

    public GameObject bulletPrefab;
    public float FirePos;

    private Transform target;
    private float spawnRate;
    private float timeAfterSpawn;

    void Start()
    {
        timeAfterSpawn = 0f;
        spawnRate = 2f;
    }

    void Update()
    {
        if (FindObjectOfType<EnemyMove>() != null)
        {
            timeAfterSpawn += Time.deltaTime;

            if (timeAfterSpawn > spawnRate)
            {
                timeAfterSpawn = 0f;

                GameObject Bullet
                    = Instantiate(bulletPrefab, transform.position, transform.rotation);

                spawnRate = 1f;
            }
        }

    }
}