using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErikOverflow.YardDefender
{
    public class EquipmentInfo : MonoBehaviour
    {
        [SerializeField] GameInfo gameInfo = null;
        [SerializeField] InventoryInfo inventoryInfo = null;
        EquipmentData equipmentData = null;
        WeaponData weaponData = null;

        public EquipmentData EquipmentData { get => equipmentData; }
        public WeaponData WeaponData { get => weaponData; }

        private void Awake()
        {
            EventManager.Instance.OnItemEquipped += EquipItem;
        }

        private void Start()
        {
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

        public void EquipItem(IEquippable equippableItem)
        {
            if (equippableItem is WeaponData _weaponData)
            {
                weaponData = _weaponData;
                equipmentData.EquippedWeapon = weaponData.Id;
                DataService.instance.UpdateRow<EquipmentData>(equipmentData);
                EventManager.Instance.PlayerEquipmentChanged();
            }
        }

        public void UnEquipWeapon()
        {
            equipmentData.EquippedWeapon = -1;
            weaponData = null;
            DataService.instance.UpdateRow<EquipmentData>(equipmentData);
            EventManager.Instance.PlayerEquipmentChanged();
        }
    }
}