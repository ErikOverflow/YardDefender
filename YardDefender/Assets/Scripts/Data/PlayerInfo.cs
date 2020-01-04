using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErikOverflow.YardDefender
{
    public class PlayerInfo : MonoBehaviour
    {
        [SerializeField] GameInfo gameInfo = null;
        [SerializeField] PlayerData playerData = null;

        public Action OnInfoChange;

        public PlayerData PlayerData { get => playerData; }

        private void Start()
        {
            gameInfo.OnInfoChange += LoadPlayerData;
            LoadPlayerData();
        }

        void LoadPlayerData()
        {
            playerData = DataService.instance.ReadRowByGameId<PlayerData>(gameInfo.SaveData.Id);
            OnInfoChange?.Invoke();
        }

        public void ChangeGold(int changeAmount)
        {
            playerData.Gold += changeAmount;
            DataService.instance.UpdateRow<PlayerData>(playerData);
            OnInfoChange?.Invoke();
        }

        public void ChangeExperience(int changeAmount)
        {
            playerData.Experience += changeAmount;
            while(playerData.Experience > CalculateExperienceNeeded())
            {
                playerData.Experience -= CalculateExperienceNeeded();
                playerData.Level++;
            }
            //leveling should be handled by a LevelController
            DataService.instance.UpdateRow<PlayerData>(playerData);
            OnInfoChange?.Invoke();
        }

        int CalculateExperienceNeeded()
        {
            return 100;
        }

        private void OnDestroy()
        {
            gameInfo.OnInfoChange -= LoadPlayerData;
        }
    }
}
