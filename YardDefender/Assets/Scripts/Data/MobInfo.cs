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
        ItemData itemDrop = null;
        PlayerInfo lastDamageSource = null;

        public Action OnDeath;

        public ItemData ItemDrop { get => itemDrop; }
        public PlayerInfo LastDamageSource { get => lastDamageSource; }
        public int Experience { get => experience; }
        public int Gold { get => gold; }

        public void Initialize(int _maxHealth, int _experience, int _gold, ItemData _itemDrop, Sprite sprite, AnimatorOverrideController aoc)
        {
            maxHealth = _maxHealth;
            currentHealth = _maxHealth;
            experience = _experience;
            gold = _gold;
            itemDrop = _itemDrop;
            spriteRenderer.sprite = sprite;
            if(aoc != null)
                animator.runtimeAnimatorController = aoc;
            animator.SetBool("Alive", true);
        }

        public void TakeDamage(int damageAmount, PlayerInfo damageSource)
        {
            if (currentHealth <= 0)
                return;
            currentHealth -= damageAmount;
            lastDamageSource = damageSource;
            if(currentHealth <= 0)
            {
                OnDeath?.Invoke();
            }
        }

    }
}