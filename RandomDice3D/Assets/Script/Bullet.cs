using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed; // 총알속도
    //public Transform target; // 타겟
    public GameObject target; // 타겟
    public bool homing; // 유도 on off
    public Vector3 disVec; // 유도 위치
    public float timerForDel; // 자동삭제 타이머
    public float timer; // 자동삭제 타이머
    public float damage = 25f;
    EnemyController enemyController;

    void Start()
    {
        //target = FindObjectOfType<EnemyMove>().transform;
        target = GameObject.FindGameObjectWithTag("Enemy");
        // bullet.setTarget(WaveManager.Instance.GetRandomEnemy());
    }

    void Update()
    {
        //if (timer > timerForDel)
        //{
        //    Destroy(gameObject);
        //}

       

        if(target == null)
        {
            Destroy(gameObject);
        }

        MeshRenderer mr = target.GetComponent<MeshRenderer>();
       if (mr.enabled == false)
        {
            Destroy(gameObject);
        }
        else if (target.activeSelf == false && target != null)
        {
            Destroy(gameObject);
        }
        else if (target.transform.position == transform.position)
        {
            Destroy(gameObject);
        }
        else
        {
            //timer += Time.deltaTime;
            if (homing)
            {
                disVec = (target.transform.position - transform.position).normalized;
            }

            transform.position += disVec * Time.deltaTime * speed;
            transform.forward = disVec;
        }
    }

    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Enemy")
    //    {
    //        other.SetActive(false);
    //    }
    //}
}