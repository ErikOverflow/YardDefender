using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErikOverflow.YardDefender
{
    public class SpawnerController : MonoBehaviour
    {
        [SerializeField] GameObject mobPrefab = null;
        [SerializeField] SpawnerInfo spawnerInfo = null;
        [SerializeField] LevelInfo levelInfo = null;
        [SerializeField] float spawnDelay = 0.5f;

        WaitForSeconds wfs = null;
        //Listen to LevelInfo to scale mobs

        Coroutine spawningCoroutine;

        private void Awake()
        {
            wfs = new WaitForSeconds(spawnDelay);
        }

        private void Start()
        {
            spawnerInfo.OnInfoChange += StartSpawning;
            StartSpawning();
        }

        void StartSpawning()
        {
            if (spawningCoroutine != null)
                StopCoroutine(spawningCoroutine);
            spawningCoroutine = StartCoroutine(Spawning());
        }

        IEnumerator Spawning()
        {
            while (spawnerInfo.MobsRemaining > 0)
            {
                MobTemplate nextMob = spawnerInfo.NextMob();
                GameObject go = ObjectPooler.instance.GetPooledObject(mobPrefab);
                go.transform.SetParent(transform);
                go.transform.localPosition = Vector3.zero;
                MobInfo mobInfo = go.GetComponent<MobInfo>();
                int mobHealth = nextMob.baseHealth * 1;
                int mobExperience = nextMob.baseExperience * 1;
                int mobGold = nextMob.baseGold * 1;
                ItemData itemDrop = RollForItem(nextMob.itemDrops);
                mobInfo.Initialize(
                    mobHealth * levelInfo.Level, //Mob health
                    mobExperience * levelInfo.Level, //Mob experience dropped
                    mobGold * levelInfo.Level, //Mob gold dropped
                    itemDrop,
                    nextMob.sprite,
                    nextMob.overrideController)
                    ;
                MobMovementInfo mobMovementInfo = go.GetComponent<MobMovementInfo>();
                mobMovementInfo.SetTarget(levelInfo.BasePosition);

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
                    if (itemTemplate is WeaponTemplate weaponTemplate)
                    {
                        return weaponTemplate.RollForWeapon();
                    }

                    //If it is a generic Item Template
                    ItemData itemData = new ItemData
                    {
                        Name = itemTemplate.name,
                        Guid = itemTemplate.GetInstanceID()
                    };
                }
            }
            return null;
        }
    }
}
