using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErikOverflow.YardDefender
{
    public class EquipmentInfo : MonoBehaviour
    {
        [SerializeField] GameInfo gameInfo = null;
        [SerializeField] EquipmentData equipmentData = null;
        [SerializeField] InventoryInfo inventoryInfo = null;
        [SerializeField] WeaponData weaponData = null;

        public Action OnInfoChange;

        public EquipmentData EquipmentData { get => equipmentData; }
        public WeaponData WeaponData { get => weaponData; }

        private void Start()
        {
            gameInfo.OnInfoChange += LoadWeapon;
            inventoryInfo.OnInfoLoaded += LoadWeapon;
            LoadWeapon();
        }

        void LoadWeapon()
        {
            equipmentData = DataService.instance.ReadRowByGameId<EquipmentData>(gameInfo.SaveData.Id);
            if (equipmentData == null)
            {
                equipmentData = DataService.instance.CreateRow<EquipmentData>();
                equipmentData.SaveId = gameInfo.SaveData.Id;
                equipmentData.EquippedWeapon = -1;
                DataService.instance.UpdateRow<EquipmentData>(equipmentData);
            }
            weaponData = inventoryInfo.GetWeaponData(equipmentData.EquippedWeapon);
            EventManager.Instance.PlayerEquipmentChanged();
        }

        public void EquipItem(ItemData itemData)
        {
            if(itemData is WeaponData _weaponData)
            {
                weaponData = _weaponData;
                equipmentData.EquippedWeapon = weaponData.Id;
            }
            DataService.instance.UpdateRow<EquipmentData>(equipmentData);
            EventManager.Instance.PlayerEquipmentChanged();
        }

        public void UnEquipItem(ItemData itemData)
        {
            if(itemData is WeaponData _weaponData)
            {
                equipmentData.EquippedWeapon = -1;
                weaponData = null;
            }
            DataService.instance.UpdateRow<EquipmentData>(equipmentData);
            EventManager.Instance.PlayerEquipmentChanged();
        }
    }
}