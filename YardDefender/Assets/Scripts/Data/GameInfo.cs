using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErikOverflow.YardDefender
{
    public class GameInfo : MonoBehaviour
    {
        [SerializeField] SaveData saveData = null;

        public SaveData SaveData { get => saveData; }

        public Action OnInfoChange;

        private void Start()
        {
            if (PlayerPrefs.HasKey(Constants.SaveIdPref))
            {
                int saveId = PlayerPrefs.GetInt(Constants.SaveIdPref);
                saveData = DataService.instance.ReadRowById<SaveData>(saveId);
                OnInfoChange?.Invoke();
            }
        }
    }
}