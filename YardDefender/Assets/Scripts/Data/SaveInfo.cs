using System;
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

            PlayerData playerData = DataService.instance.CreateRow<PlayerData>();
            playerData.SaveId = saveData.Id;
            DataService.instance.UpdateRow<PlayerData>(playerData);

            EquipmentData equipmentData = DataService.instance.CreateRow<EquipmentData>();
            equipmentData.SaveId = saveData.Id;
            equipmentData.EquippedWeapon = -1;
            DataService.instance.UpdateRow<EquipmentData>(equipmentData);
            //ItemData itemData = DataService.instance.CreateRow<ItemData>();
            //itemData.SaveId = saveData.Id;
            //DataService.instance.UpdateRow<ItemData>(itemData);
            return saveData.Id;
        }
    }
}