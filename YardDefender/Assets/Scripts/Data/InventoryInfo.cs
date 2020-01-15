using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ErikOverflow.YardDefender
{
    public class InventoryInfo : MonoBehaviour
    {
        [SerializeField] GameInfo gameInfo = null;
        [SerializeField] List<ItemData> itemDatas = null;
        [SerializeField] List<WeaponData> weaponDatas = null;

        public List<WeaponData> WeaponDatas { get => weaponDatas; }
        public List<ItemData> ItemDatas { get => itemDatas; }

        private void Awake()
        {
            EventManager.Instance.OnItemUsed += UseItem;
        }

        private void UseItem(ItemData itemData)
        {
            WeaponData weaponData = weaponDatas.FirstOrDefault(wd => wd.ItemId == itemData.Id);
            if(weaponData != null)
            {
                EventManager.Instance.EquipItem(weaponData);
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            LoadInventoryData();
        }

        void LoadInventoryData()
        {
            itemDatas = DataService.instance.ReadRowsByGameId<ItemData>(gameInfo.SaveData.Id).ToList();
            weaponDatas = DataService.instance.ReadRowsByGameId<WeaponData>(gameInfo.SaveData.Id).ToList();
            EventManager.Instance.InventoryChanged();
        }

        public WeaponData GetWeaponData(int id)
        {
            return weaponDatas.FirstOrDefault(wd => wd.Id == id);
        }

        public void AddItem(ItemData itemData)
        {
            //Insert any type of item into ItemData, assigning a primary key
            itemData.SaveId = gameInfo.SaveData.Id;
            DataService.instance.InsertRow<ItemData>(itemData); //This should automatically assign an Id on insert.
            itemDatas.Add(itemData);
            if (itemData is WeaponData weaponData)
            {
                WeaponData wd = DataService.instance.CreateRow<WeaponData>();
                weaponData.ItemId = itemData.Id;
                weaponData.Id = wd.Id;
                DataService.instance.UpdateRow<WeaponData>(weaponData);
                weaponDatas.Add(weaponData);
            }
            EventManager.Instance.InventoryChanged();
        }
    }
}
