using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float EnemyHP = 100.0f;
    public float BulletDamage;
    SpawnPoints spawnPoints;
    public Bullet bulletPrefab;

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
            Debug.Log("ºÒ·¿ È®ÀÎ");
            //EnemyHP -= BulletDamage;
            EnemyHP -= bulletPrefab.damage;
        }
    }
}