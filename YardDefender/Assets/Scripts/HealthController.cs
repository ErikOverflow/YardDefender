using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField]
    int health = 10;
    bool alive = true;

    public Action OnDeath;

    public void TakeDamage(int damage)
    {
        if (!alive)
            return;
        health -= damage;
        if(health <= 0)
        {
            health = 0;
            OnDeath?.Invoke();
            alive = false;
        }
    }
}
