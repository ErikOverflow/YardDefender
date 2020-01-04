using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErikOverflow.YardDefender
{
    public class MobInfo : MonoBehaviour
    {
        [SerializeField] SpriteRenderer spriteRenderer = null;
        [SerializeField] Animator animator = null;

        [SerializeField] int currentHealth = 0;
        [SerializeField] int maxHealth = 0;
        [SerializeField] int experience = 0;
        [SerializeField] int gold = 0;
        [SerializeField] ItemData itemDrop = null;

        public Action OnInfoChange;

        public void Initialize(int _maxHealth, int _experience, int _gold, ItemData _itemDrop, Sprite sprite, AnimatorOverrideController aoc)
        {
            maxHealth = _maxHealth;
            currentHealth = _maxHealth;
            experience = _experience;
            gold = _gold;
            itemDrop = _itemDrop;
            spriteRenderer.sprite = sprite;
            animator.runtimeAnimatorController = aoc;
        }
    
    }
}