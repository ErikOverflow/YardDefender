﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ErikOverflow.YardDefender
{
    public class InventoryInfo : MonoBehaviour
    {
        [SerializeField] GameInfo gameInfo = null;
        //Generic Items
        [SerializeField] List<ItemData> itemDatas = null;
        //Just weapon data
        [SerializeField] List<WeaponData> weaponDatas = null;

        public List<ItemData> ItemDatas { get => itemDatas; }
        public List<WeaponData> WeaponDatas { get => weaponDatas; }
        public List<ItemData> AllItemDatas { get => new List<ItemData>().Concat(itemDatas).Concat(weaponDatas).ToList(); }

        public Action OnInfoChange;
        public Action OnInfoLoaded;

        // Start is called before the first frame update
        void Start()
        {
            gameInfo.OnInfoChange += LoadInventoryData;
            LoadInventoryData();
        }

        void LoadInventoryData()
        {
            itemDatas = DataService.instance.ReadRowsByGameId<ItemData>(gameInfo.SaveData.Id).ToList();
            weaponDatas = DataService.instance.ReadRowsByGameId<WeaponData>(gameInfo.SaveData.Id).ToList();
            OnInfoChange?.Invoke();
            OnInfoLoaded?.Invoke();
        }

        public WeaponData GetWeaponData(int id)
        {
            return weaponDatas.FirstOrDefault(wd => wd.Id == id);
        }

        public void AddItem(ItemData itemData)
        {
            itemData.SaveId = gameInfo.SaveData.Id;
            if (itemData is WeaponData weaponData)
            {
                weaponDatas.Add(weaponData);
                DataService.instance.InsertRow<WeaponData>(weaponData);
            }
            else
            {
                itemDatas.Add(itemData);
                DataService.instance.InsertRow<ItemData>(itemData);
            }
            OnInfoChange?.Invoke();
        }

        private void OnDestroy()
        {
            gameInfo.OnInfoChange -= LoadInventoryData;
        }
    }
}
