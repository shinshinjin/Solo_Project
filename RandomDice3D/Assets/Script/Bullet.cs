using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed; // �Ѿ˼ӵ�
    //public Transform target; // Ÿ��
    public GameObject target; // Ÿ��
    public bool homing; // ���� on off
    public Vector3 disVec; // ���� ��ġ
    public float timerForDel; // �ڵ����� Ÿ�̸�
    public float timer; // �ڵ����� Ÿ�̸�
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