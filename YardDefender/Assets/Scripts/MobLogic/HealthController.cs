//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class HealthController : MonoBehaviour
//{
//    [SerializeField] int health = 10;
//    [SerializeField] int maxHealth = 10;
//    [SerializeField] GameObject mobHealthBarPrefab;
//    [SerializeField] MobStats mobStats = null;
//    bool alive = true;
//    GameObject healthBar = null;

//    PlayerInfo lastAttacker = null;
//    public PlayerInfo LastAttacker { get => lastAttacker; }
//    public bool Alive { get => alive; }

//    public Action OnDeath;
//    public Action OnDamage;

//    public void Initialize()
//    {
//        maxHealth = mobStats.Health;
//        health = mobStats.Health;
//        healthBar = UIController.instance.CreateMobHealthBar(this);
//    }

//    public void TakeDamage(int damage, PlayerInfo playerInfo)
//    {
//        if (!alive)
//            return;
//        lastAttacker = playerInfo;
//        health -= damage;
//        OnDamage?.Invoke();
//        if (health <= 0)
//        {
//            health = 0;
//            OnDeath?.Invoke();
//            alive = false;
//        }
//    }

//    public float GetPercent()
//    {
//        return (float)health / maxHealth;
//    }
//}
