using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ErikOverflow.YardDefender
{
    public class LevelInfo : MonoBehaviour
    {
        [SerializeField] Transform basePosition = null;
        [SerializeField] int level = 1;
        [SerializeField] List<LevelTemplate> levelTemplates = null;
        HashSet<SpawnerInfo> activeSpawners = null;
        LevelTemplate currentLevel = null;

        public Transform BasePosition { get => basePosition; }
        public int Level { get => level; }
        public LevelTemplate CurrentLevel { get => currentLevel; }

        private void Awake()
        {
            activeSpawners = new HashSet<SpawnerInfo>();
            EventManager.Instance.OnSpawnerConfigured += AddActiveSpawner;
            EventManager.Instance.OnSpawnerDefeated += RemoveActiveSpawner;
        }

        private void RemoveActiveSpawner(SpawnerInfo spawner)
        {
            activeSpawners.Remove(spawner);
            if (activeSpawners.Count == 0)
                EventManager.Instance.LevelDefeated(this);
        }

        private void AddActiveSpawner(SpawnerInfo spawner)
        {
            activeSpawners.Add(spawner);
        }

        private void Start()
        {
            ChangeLevel(1);
        }

        public void ChangeLevel(int newLevel)
        {
            level = newLevel;
            currentLevel = levelTemplates.FirstOrDefault(lt => lt.levelNum == level);
            EventManager.Instance.LevelChanged();
        }
    }
}