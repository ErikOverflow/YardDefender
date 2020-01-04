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
        [SerializeField] List<WeightedMobRecord> mobs = null;
        [SerializeField] int mobsRemaining = 0;
        int totalWeight = 0;

        public int MobsRemaining { get => mobsRemaining; }

        private void Awake()
        {
            mobsRemaining = 10;
            totalWeight = mobs.Sum(m => m.weight);
        }

        public MobTemplate NextMob()
        {
            if (mobsRemaining <= 0)
                return null;
            mobsRemaining--;
            int mobSelection = Random.Range(0, totalWeight);
            foreach (WeightedMobRecord mr in mobs)
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

    [Serializable]
    public struct WeightedMobRecord
    {
        public MobTemplate template;
        public int weight;
    }
}
