using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float EnemyHP = 100.0f;
    public float BulletDamage;
    SpawnPoints spawnPoints;
    public Bullet bulletPrefab;

    private bool DieCheck=false;
    private void Start()
    {
       spawnPoints = GameObject.Find("SpawnPoints").GetComponent<SpawnPoints>();
    }
    void Update()
    {
        if (EnemyHP <= 0)
        {
            //Animator.SetTrigger("EnemyAttacked");    
            StartCoroutine(Die());

            if(DieCheck == false)
            {
                spawnPoints.PlayerMoney += 50f;
                DieCheck = true;
            }
            
            // spawnPoints.PlayerMoney += 40;
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
            Debug.Log("∫“∑ø »Æ¿Œ");
            //EnemyHP -= BulletDamage;
            EnemyHP -= bulletPrefab.damage;
        }
    }
}