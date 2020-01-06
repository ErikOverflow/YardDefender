using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErikOverflow.YardDefender
{
    public class PlayerInfo : MonoBehaviour
    {
        [SerializeField] GameInfo gameInfo = null;
        [SerializeField] EquipmentInfo equipmentInfo = null;
        [SerializeField] PlayerData playerData = null;
        
        public Action OnInfoChange;
        
        public PlayerData PlayerData { get => playerData; }
        public int Attack
        {
            get
            {
                if (equipmentInfo.WeaponData == null)
                    return 1;
                return Mathf.FloorToInt(equipmentInfo.WeaponData.Damage * equipmentInfo.WeaponData.Multiplier);
            }
        }
        public float BarkSize
        {
            get
            {
                return 1f + playerData.Level / 2f;
            }
        }

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
            return Mathf.FloorToInt(Mathf.Pow(1.1f, playerData.Level) * 100f);
        }

        private void OnDestroy()
        {
            gameInfo.OnInfoChange -= LoadPlayerData;
        }
    }
}
