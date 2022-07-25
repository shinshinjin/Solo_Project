using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float EnemyHP = 100.0f;
    public bool isDead = false;

    void Start()
    {
        isDead = false;
    }

    void Update()
    {


        if (EnemyHP > 0)
        {
            die();
        }
    }

    void die()
    {
        isDead = true;
    }
}
