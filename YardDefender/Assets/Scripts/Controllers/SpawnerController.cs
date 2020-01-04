﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErikOverflow.YardDefender
{
    public class SpawnerController : MonoBehaviour
    {
        [SerializeField] GameObject mobPrefab = null;
        [SerializeField] SpawnerInfo spawnerInfo = null;
        [SerializeField] float spawnDelay = 0.5f;

        WaitForSeconds wfs = null;
        //Listen to LevelInfo to scale mobs

        private void Awake()
        {
            wfs = new WaitForSeconds(spawnDelay);
        }

        private void Start()
        {
            StartSpawning();
        }

        void StartSpawning()
        {
            StartCoroutine(Spawning());
        }

        IEnumerator Spawning()
        {
            while (spawnerInfo.MobsRemaining > 0)
            {
                MobTemplate nextMob = spawnerInfo.NextMob();
                GameObject go = ObjectPooler.instance.GetPooledObject(mobPrefab);
                MobInfo mobInfo = go.GetComponent<MobInfo>();
                int mobHealth = nextMob.baseHealth * 1;
                int mobExperience = nextMob.baseExperience * 1;
                int mobGold = nextMob.baseGold * 1;
                ItemData itemDrop = RollForItem(nextMob.itemDrops);
                mobInfo.Initialize(mobHealth, mobExperience, mobGold, itemDrop, nextMob.sprite, nextMob.overrideController);
                go.transform.SetParent(transform);
                go.transform.localPosition = Vector3.zero;

                if (spawnerInfo.MobsRemaining == 0)
                {
                    yield break;
                }
                yield return wfs;
            }
        }

        ItemData RollForItem(List<ItemDrop> itemDrops)
        {
            float dropRoll = Random.Range(0f, 1f);
            ItemTemplate itemTemplate = null;
            foreach (ItemDrop drop in itemDrops)
            {
                dropRoll -= drop.dropRate;
                if (dropRoll < 0)
                {
                    itemTemplate = drop.itemTemplate;

                    //If it's a Weapon Template
                    if(itemTemplate is WeaponTemplate weaponTemplate)
                    {
                        WeaponData weaponData = new WeaponData
                        {
                            Damage = Random.Range(weaponTemplate.flatDamageMin, weaponTemplate.flatDamageMax),
                            Multiplier = Random.Range(weaponTemplate.multiplierDamageMin, weaponTemplate.multiplierDamageMax),
                            Name = weaponTemplate.name
                        };
                        return weaponData;
                    }

                    //If it is a generic Item Template
                    ItemData itemData = new ItemData
                    {
                        Name = itemTemplate.name
                    };
                }
            }
            return null;
        }
    }
}
