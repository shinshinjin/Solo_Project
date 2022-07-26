using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float EnemyHP = 100.0f;
    public float BulletDamage;
    SpawnPoints spawnPoints;
    Bullet bullet;

    void Start()
    {

    }

    void Update()
    {
        if (EnemyHP <= 0)
        {
            //Animator.SetTrigger("EnemyAttacked");    
            gameObject.SetActive(false);
           // spawnPoints.PlayerMoney += 40;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            EnemyHP -= BulletDamage;
        }
    }
}