using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErikOverflow.YardDefender
{
    [CreateAssetMenu(fileName = "New Mob Template", menuName = "Create New Mob Template", order = 0)]
    public class MobTemplate : ScriptableObject
    {
        public Sprite sprite;
        public int baseHealth;
        public int baseExperience;
        public int baseGold;
        public AnimatorOverrideController overrideController;
        public List<ItemDrop> itemDrops;
    }

    public struct ItemDrop
    {
        public ItemTemplate itemTemplate;
        public float dropRate;
    }
}