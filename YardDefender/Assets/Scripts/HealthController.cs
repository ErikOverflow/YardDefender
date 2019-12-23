using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField]
    int health = 10;
    bool alive = true;
    PlayerStats lastAttacker = null;
    public PlayerStats LastAttacker { get => lastAttacker; }

    public Action OnDeath;

    private void OnEnable()
    {
        MobStats mobStats = GetComponent<MobStats>();
        health = mobStats.BaseHealth;
    }

    public void TakeDamage(int damage, PlayerStats playerStats)
    {
        if (!alive)
            return;
        lastAttacker = playerStats;
        health -= damage;
        if(health <= 0)
        {
            health = 0;
            OnDeath?.Invoke();
            alive = false;
        }
    }
}
