using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawnPosition : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float FirePos;

    private DiceManager DM;
    private Bullet bullet;
    private Transform target;
    private float spawnRate;
    private float timeAfterSpawn;

    void Start()
    {
        timeAfterSpawn = 0f;
        spawnRate = 2f;
        DM = gameObject.GetComponent<DiceManager>();
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

                /*if(부모 다이스의 타입이 불잉ㄹ 댸)
                 * {
                 * Bullet(오브젝).Bullet(스크립트).speed(변수) = 10;              
                   } 
                 else if (부모다이스의 타입이 어떵떠얻일)
                 {
                 * Bullet(오브젝).Bullet(스크립트).speed(변수) = 10;
                  }
                Gameobject a = gameobject.transform.getparent
                Gameobject b = a.transform.get...*/


                spawnRate = 1f;
            }
        }

    }
}