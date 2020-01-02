﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIWeaponSlot : MonoBehaviour
{
    [SerializeField] Image image = null;
    PlayerEquipment playerEquipment = null;
    WeaponData weaponData = null;

    public void RenderWeapon(WeaponData _weaponData, PlayerEquipment _playerEquipment)
    {
        Weapon weapon = WeaponTable.instance.GetWeapon(_weaponData.Name);
        if (weapon == null)
            throw new WeaponNotInGlobalTableException(_weaponData.Name);
        weaponData = _weaponData;
        playerEquipment = _playerEquipment;
        image.sprite = weaponData.Sprite;
    }

    public void EquipWeapon()
    {
        playerEquipment.EquipWeapon(weaponData);
    }
}
