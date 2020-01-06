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
        [SerializeField] int mobsRemaining = 0;
        int totalWeight = 0;

        public int MobsRemaining { get => mobsRemaining; }

        public Action OnInfoChange;

        private void Start()
        {
            levelInfo.OnInfoChange += ConfigureSpawner;
            ConfigureSpawner();
        }

        private void ConfigureSpawner()
        {
            mobsRemaining = levelInfo.LevelTemplate.totalSpawns;
            totalWeight = levelInfo.LevelTemplate.TotalWeight;
            OnInfoChange?.Invoke();
        }

        public MobTemplate NextMob()
        {
            mobsRemaining--;
            int mobSelection = Random.Range(0, totalWeight);
            foreach (WeightedMobRecord mr in levelInfo.LevelTemplate.mobs)
            {
                mobSelection -= mr.weight;
                if (mobSelection < 0)
                {
                    return mr.template;
                }
            }
            return null;

        }
    }
}
