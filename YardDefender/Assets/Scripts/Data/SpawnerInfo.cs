using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ErikOverflow.YardDefender
{
    public class SpawnerInfo : MonoBehaviour
    {
        [SerializeField] LevelInfo levelInfo = null;
        public HashSet<MobInfo> activeSpawnedMobs = null;
        Queue<MobTemplate> mobs;
        MobTemplate bossMob = null;
        int totalWeight = 0;

        public MobTemplate BossMob { get => bossMob; }
        public int MobsRemaining { get => mobs.Count; }

        private void Awake()
        {
            EventManager.instance.OnLevelChanged += ConfigureSpawner;
            EventManager.instance.OnMobKilled += RemoveMobFromTracking;
        }

        private void RemoveMobFromTracking(MobInfo mob)
        {
            activeSpawnedMobs.Remove(mob);
            //There are no living spawned mobs, and no mobs left to spawn
            if(activeSpawnedMobs.Count + mobs.Count == 0)
            {
                EventManager.instance.SpawnerDefeated(this);
            }
        }

        private void ConfigureSpawner()
        {
            mobs = new Queue<MobTemplate>();
            totalWeight = levelInfo.CurrentLevel.TotalWeight;
            //Go through and generate all of the current level's mob data ahead of time
            for(int i = 0; i < levelInfo.CurrentLevel.totalSpawns; i++)
            {
                int selection = Random.Range(0, totalWeight);
                foreach(WeightedMobRecord mr in levelInfo.CurrentLevel.mobs)
                {
                    selection -= mr.weight;
                    if(selection < 0)
                    {
                        mobs.Enqueue(mr.template);
                        break;
                    }
                }
            }
            //If there's a boss, it's the last mob
            if(bossMob != null)
                mobs.Enqueue(bossMob);
            activeSpawnedMobs = new HashSet<MobInfo>();
            EventManager.instance.SpawnerConfigured(this);
        }

        public MobTemplate NextMob()
        {
            return mobs.Dequeue();
        }
    }
}
