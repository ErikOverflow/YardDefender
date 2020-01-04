using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErikOverflow.YardDefender
{
    public class PlayerInfo : MonoBehaviour
    {
        [SerializeField] int saveId = 0;
        [SerializeField] PlayerData playerData = null;

        public Action OnInfoChange;

        public PlayerData PlayerData { get => playerData; }

        // Start is called before the first frame update
        void Start()
        {
            if (PlayerPrefs.HasKey(Constants.SaveIdPref))
            {
                saveId = PlayerPrefs.GetInt(Constants.SaveIdPref);
            }
            playerData = DataService.instance.ReadRowByGameId<PlayerData>(saveId);
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
    }
}
