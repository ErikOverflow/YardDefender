﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlayerEquipment : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats = null;
    [SerializeField] WeaponData equippedWeapon = null;
    //Can reroll all stats with gold
    //Can prestige weapons with gold after a certain number of kills with the weapon. Prestige unlocks special ability.
    //Drops from enemies, with a minimum of 1% before it can drop (requiring higher difficulty levels to get some items)
    [SerializeField] List<WeaponData> weaponInventory = new List<WeaponData>();

    public bool WeaponEquipped { get => equippedWeapon != null; }
    public int WeaponEquippedId { get => equippedWeapon.Id; }
    public int FlatDamage { get => equippedWeapon.FlatDamage; }
    public float MultiplierDamage { get => equippedWeapon.DamageMultiplier; }
    public IEnumerable<WeaponData> WeaponInventory { get => weaponInventory; }

    public Action OnEquipmentChange;

    public void EquipWeapon(WeaponData newWeapon)
    {
        equippedWeapon = newWeapon;
        newWeapon.Equipped = true;
        DataService.instance.UpdateWeaponData(newWeapon);
        OnEquipmentChange?.Invoke();
    }

    public void PickupWeapon(WeaponData newWeapon)
    {
        weaponInventory.Add(newWeapon);
        newWeapon.Id = DataService.instance.CreateWeaponData();
        newWeapon.PlayerId = playerStats.PlayerId;
        DataService.instance.UpdateWeaponData(newWeapon);
    }

    public void Initialize(IEnumerable<WeaponData> weaponDatas)
    {
        weaponInventory = weaponDatas.ToList();
        equippedWeapon = weaponDatas.FirstOrDefault(wd => wd.Equipped);
    }
}
