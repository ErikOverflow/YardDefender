using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ErikOverflow.YardDefender
{
    [CreateAssetMenu(fileName = "New Level", menuName = "Create New Level Template", order = 0)]
    public class LevelTemplate : ScriptableObject
    {
        public int levelNum;
        public List<WeightedMobRecord> mobs;
        public MobTemplate finalBoss;
        public int totalSpawns;

        public int TotalWeight
        {
            get
            {
                return mobs.Sum(m => m.weight);
            }
        }
    }

    [Serializable]
    public struct WeightedMobRecord
    {
        public MobTemplate template;
        public int weight;
    }
}