using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed; // �Ѿ˼ӵ�
    public GameObject target; // Ÿ��
    public bool homing; // ���� on off
    public Vector3 disVec; // ���� ��ġ
    public float timerForDel; // �ڵ����� Ÿ�̸�
    public float timer; // �ڵ����� Ÿ�̸�
    public int damage = 10;
    EnemyController enemyController;

    public static Bullet instance_B;

    public void Awake()
    {
        if (instance_B == null)
        {
            instance_B = this;
        }
    }

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Enemy");
    }

    void Update()
    {
        MeshRenderer mr = target.GetComponent<MeshRenderer>();

        if (mr == null)
        {
            Destroy(gameObject);
        }
        else if (target == null)
        {
            Destroy(gameObject);
        }
        else if (mr.enabled == false)
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
            if (homing)
            {
                disVec = (target.transform.position - transform.position).normalized;
            }

            transform.position += disVec * Time.deltaTime * speed;
            transform.forward = disVec;
            Destroy(mr.gameObject, 10f);
        }
    }

    public void DamageUp()
    {
        damage += 20;
    }
}