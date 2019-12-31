﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LootController : MonoBehaviour
{
    [SerializeField] HealthController healthController = null;
    [SerializeField] GameObject weaponPrefab = null;
    List<Weapon> weapons = new List<Weapon>();

    private void Start()
    {
        healthController.OnDeath += Drop;
    }

    private void Drop()
    {
        foreach(Weapon weapon in weapons)
        {
            GameObject go = ObjectPooler.instance.GetPooledObject(weaponPrefab);
            go.transform.position = transform.position;
            LootWeapon lw = go.GetComponent<LootWeapon>();
            lw.Initialize(weapon);
        }
    }

    public void Initialize(List<WeaponDrop> weaponDrops)
    {
        foreach(WeaponDrop weaponDrop in weaponDrops)
        {
            float roll = Random.Range(0f, 1f);
            if (roll < weaponDrop.dropChance)
                weapons.Add(weaponDrop.weapon);
        }
    }

    public void OnDestroy()
    {
        healthController.OnDeath -= Drop;
    }
}