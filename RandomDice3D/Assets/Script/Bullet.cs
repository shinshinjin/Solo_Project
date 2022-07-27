using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed; // �Ѿ˼ӵ�
    public Transform target; // Ÿ��
    public bool homing; // ���� on off
    public Vector3 disVec; // ���� ��ġ
    public float timerForDel; // �ڵ����� Ÿ�̸�
    public float timer; // �ڵ����� Ÿ�̸�
    EnemyController enemyController;

    void Start()
    {
        target = FindObjectOfType<EnemyMove>().transform;
        // bullet.setTarget(WaveManager.Instance.GetRandomEnemy());
    }

    void Update()
    {
        if (timer > timerForDel)
        {
            Destroy(gameObject);
        }

        else
        {
            timer += Time.deltaTime;
            if (homing)
            {
                disVec = (target.transform.position - transform.position).normalized;
            }

            transform.position += disVec * Time.deltaTime * speed;
            transform.forward = disVec;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}