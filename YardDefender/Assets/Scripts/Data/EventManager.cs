﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErikOverflow.YardDefender
{
    public class EventManager : MonoBehaviour
    {

        /*
         * RULE: Data is NEVER copied from one system to another.
         * Any data that is dependent on data in other scripts will be calculated on the spot or passed by reference to the source.
         */
        static EventManager instance;

        public static EventManager Instance { get => instance; }

        private void Awake()
        {
            instance = this;
        }

        public event Action OnLevelChanged;
        /*
         * Things that should happen when the level changes:
         * - Spawner should stop spawning enemies
         * - All enemies should disappear
         * - Animation should play to bring you to next level
         * - Spawner should be updated to include the new list of mobs
         * - Rest the portal button to the next level
         */
        public void LevelChanged()
        {
            OnLevelChanged?.Invoke();
        }

        public event Action OnLevelStarted;
        /*
         * Should run one frame after level changed
         */
         public void LevelStarted()
        {
            OnLevelStarted?.Invoke();
        }

        public event Action<MobInfo> OnMobSpawned;
        /*
         * - Start the mob moving
         */
        public void MobSpawned(MobInfo mobInfo)
        {
            OnMobSpawned?.Invoke(mobInfo);
        }

        public event Action<MobInfo> OnMobKilled;
        /*
         * Things that should happen when a mob dies:
         * - Player gains exp and gold
         * - Death sound plays
         * - Item drops if there was an item
         * - The mob needs to play its death animation
         * - The Spawner Info needs to know that one of the mobs it spawned has died
         */
        public void MobKilled(MobInfo mobInfo)
        {
            OnMobKilled?.Invoke(mobInfo);
        }

        public Action OnPlayerLevelChanged;

        public void PlayerLevelChanged()
        {
            OnPlayerLevelChanged?.Invoke();
        }

        public Action<SpawnerInfo> OnSpawnerDefeated;

        public void SpawnerDefeated(SpawnerInfo spawnerInfo)
        {
            OnSpawnerDefeated?.Invoke(spawnerInfo);
        }

        public Action OnPlayerInfoChanged;

        public void PlayerInfoChanged()
        {
            OnPlayerInfoChanged?.Invoke();
        }

        public Action OnPlayerEquipmentChanged;

        public void PlayerEquipmentChanged()
        {
            OnPlayerEquipmentChanged?.Invoke();
        }
    }
}
