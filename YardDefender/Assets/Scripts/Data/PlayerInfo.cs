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
            EventManager.Instance.OnMobKilled += HandleMobKill;
            LoadPlayerData();
        }

        private void HandleMobKill(MobInfo mob)
        {
            if(mob.LastDamageSource == this)
            {
                ChangeGold(mob.Gold);
                ChangeExperience(mob.Experience);
            }
        }

        void LoadPlayerData()
        {
            playerData = DataService.instance.ReadRowByGameId<PlayerData>(gameInfo.SaveData.Id);
            EventManager.Instance.PlayerInfoChanged();
        }

        void ChangeGold(int changeAmount)
        {
            playerData.Gold += changeAmount;
            DataService.instance.UpdateRow<PlayerData>(playerData);
            EventManager.Instance.PlayerInfoChanged();
        }

        void ChangeExperience(int changeAmount)
        {
            playerData.Experience += changeAmount;
            while(playerData.Experience > CalculateExperienceNeeded())
            {
                playerData.Experience -= CalculateExperienceNeeded();
                playerData.Level++;
                EventManager.Instance.PlayerLevelChanged();
            }
            DataService.instance.UpdateRow<PlayerData>(playerData);
            EventManager.Instance.PlayerInfoChanged();
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
