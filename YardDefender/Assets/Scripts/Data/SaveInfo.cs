﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErikOverflow.YardDefender
{
    public class SaveInfo : MonoBehaviour
    {
        IEnumerable<SaveData> saveDatas = null;

        public IEnumerable<SaveData> SaveDatas { get => saveDatas; }

        public Action OnInfoChanged;

        private void Start()
        {
            saveDatas = DataService.instance.ReadAllRows<SaveData>();
            OnInfoChanged?.Invoke();
        }

        public int NewGame(string name)
        {
            SaveData saveData = DataService.instance.CreateRow<SaveData>();
            saveData.Name = name;
            DataService.instance.UpdateRow<SaveData>(saveData);
            return saveData.Id;
        }
    }
}