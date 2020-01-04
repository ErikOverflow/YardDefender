using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ErikOverflow.YardDefender
{
    public class HealthInfo : MonoBehaviour
    {
        [SerializeField] PlayerInfo playerInfo = null;
        [SerializeField] HealthData healthData = null;

        public HealthData HealthData { get => healthData; }

        public Action OnInfoChange;

        public void Start()
        {
            playerInfo.OnInfoChange += LoadHealthData;
            //Listen to LevelInfo for level up and have it call
            LoadHealthData();
            ResetHealthData();
        }

        void LoadHealthData()
        {
            healthData.MaxHealth = playerInfo.PlayerData.Level * 10;
        }

        void ResetHealthData()
        {
            LoadHealthData();
            healthData.CurrentHealth = healthData.MaxHealth;
        }
    }
}