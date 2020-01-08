using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErikOverflow.YardDefender
{
    public class PortalInfo : MonoBehaviour
    {
        [SerializeField] LevelInfo levelInfo = null;
        int nextLevel = 0;

        public int NextLevel { get => nextLevel; }

        void Start()
        {
            EventManager.Instance.OnLevelChanged += ConfigurePortal;
        }

        void ConfigurePortal()
        {
            nextLevel = levelInfo.Level + 1;
        }
    }
}