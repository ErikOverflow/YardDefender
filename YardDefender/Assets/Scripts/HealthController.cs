﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField] int health = 10;
    [SerializeField] int maxHealth = 10;
    [SerializeField] GameObject mobHealthBarPrefab;
    [SerializeField] MobStats mobStats;
    bool alive = true;
    PlayerStats lastAttacker = null;
    public PlayerStats LastAttacker { get => lastAttacker; }

    public Action OnDeath;
    public Action OnDamage;

    public void Initialize()
    {
        maxHealth = mobStats.BaseHealth;
        health = mobStats.BaseHealth;
    }

    public void TakeDamage(int damage, PlayerStats playerStats)
    {
        if (!alive)
            return;
        lastAttacker = playerStats;
        health -= damage;
        OnDamage?.Invoke();
        if(health <= 0)
        {
            health = 0;
            OnDeath?.Invoke();
            alive = false;
        }
    }

    public float GetPercent()
    {
        return (float) health / maxHealth;
    }
}
