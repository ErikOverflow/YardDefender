using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErikOverflow.YardDefender
{
    public class PortalInfo : MonoBehaviour
    {
        public static PortalInfo instance;
        [SerializeField] LevelInfo levelInfo = null;
        int levelChange = 1;
        int mobsNeeded = 0;
        int mobsKilled = 0;
        bool active = false;

        public Action OnInfoChange;

        public bool Active { get => active; }
        public int LevelChange { get => levelChange; }

        private void Awake()
        {
            instance = this;
        }

        void Start()
        {
            levelInfo.OnLevelChange += UpdatePortal;
            UpdatePortal();
        }

        void UpdatePortal()
        {
            mobsKilled = 0;
            mobsNeeded = levelInfo.LevelTemplate.totalSpawns;
            active = false;
            OnInfoChange?.Invoke();
        }

        public void MobKilled()
        {
            mobsKilled++;
            if(mobsKilled >= mobsNeeded)
            {
                active = true;
            }
            OnInfoChange?.Invoke();
        }
    }
}