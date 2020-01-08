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
        LevelTemplate currentLevel = null;

        public Transform BasePosition { get => basePosition; }
        public int Level { get => level; }
        public LevelTemplate CurrentLevel { get => currentLevel; }

        private void Start()
        {
            ChangeLevel(1);
            EventManager.Instance.LevelStarted();
        }

        IEnumerator DelayedStart()
        {
            yield return null;
            EventManager.Instance.LevelStarted();
        }

        public void ChangeLevel(int newLevel)
        {
            level = newLevel;
            currentLevel = levelTemplates.FirstOrDefault(lt => lt.levelNum == level);
            EventManager.Instance.LevelChanged();
        }
    }
}