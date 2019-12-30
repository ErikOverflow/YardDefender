using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{
    WeaponData weaponData = new WeaponData();
    //Can reroll all stats with gold
    //Can prestige weapons with gold after a certain number of kills with the weapon. Prestige unlocks special ability.
    //Drops from enemies, with a minimum of 1% before it can drop (requiring higher difficulty levels to get some items)
    public List<WeaponData> weaponInventory = new List<WeaponData>();


    public int FlatDamage { get => weaponData.FlatDamage; }
    public float MultiplierDamage { get => weaponData.DamageMultiplier; }
    public IEnumerable<WeaponData> WeaponInventory { get => weaponInventory; }

    public Action OnEquipmentChange;

    public void EquipWeapon(WeaponData newWeapon)
    {
        OnEquipmentChange?.Invoke();
        ActiveGame.instance.SaveGame();
    }

    internal IEnumerable<WeaponData> FirstOrDefault()
    {
        throw new NotImplementedException();
    }
}
