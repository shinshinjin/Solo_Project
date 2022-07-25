using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    public float EnemySpeed;
    public Transform GoalTarget;
    int nextTarget;

    private void Start()
    {
        GoalTarget = GameManager.instance.target[nextTarget];
        GetComponent<NavMeshAgent>().speed = EnemySpeed;
        StartCoroutine("Enemy_Move");
    }

    IEnumerator Enemy_Move()
    {
        GetComponent<NavMeshAgent>().SetDestination(GoalTarget.position);
        while (true)
        {
            float dis = (GoalTarget.position - transform.position).magnitude;
            if (dis <= 1)
            {
                nextTarget += 1;
                GoalTarget = GameManager.instance.target[nextTarget];
                GetComponent<NavMeshAgent>().SetDestination(GoalTarget.position);

            }
            yield return null;
        }
    }

}
