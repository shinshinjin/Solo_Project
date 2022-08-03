using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : MonoBehaviour
{
    public int EnemyHP = 100;
    private float BulletDamage;
    public Bullet bulletPrefab;

    private bool DieCheck = false;
    public static EnemyController instance_EC;

    SpawnPoints spawnPoints;

    public void Awake()
    {
        if(instance_EC == null)
        {
            instance_EC = this;
        }
    }

    private void Start()
    {
        spawnPoints = GameObject.Find("SpawnPoints").GetComponent<SpawnPoints>();
    }
    void Update()
    {
        if (EnemyHP <= 0)
        { 
            StartCoroutine(Die());

            if (DieCheck == false)
            {
                spawnPoints.PlayerMoney += 50f;
                DieCheck = true;
            }
        }
    }
    IEnumerator Die()
    {
        MeshRenderer MR = this.gameObject.GetComponent<MeshRenderer>();
        MR.enabled = false;

        yield return new WaitForSeconds(1f);
        Destroy(gameObject);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            EnemyHP -= bulletPrefab.damage;
        }
    }
    public void EnemyHpUp()
    {
        EnemyHP += 100;
    }
}