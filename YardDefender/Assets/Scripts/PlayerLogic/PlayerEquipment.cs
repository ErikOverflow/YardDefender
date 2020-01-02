using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Collider2D))]
public class PlayerEquipment : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats = null;
    [SerializeField] WeaponData equippedWeapon = null;
    //Can reroll all stats with gold
    //Can prestige weapons with gold after a certain number of kills with the weapon. Prestige unlocks special ability.
    //Drops from enemies, with a minimum of 1% before it can drop (requiring higher difficulty levels to get some items)
    [SerializeField] List<WeaponData> weaponInventory = new List<WeaponData>();
    List<WeaponData> changedWeapons = new List<WeaponData>();

    public bool WeaponEquipped { get => equippedWeapon != null; }
    public int WeaponEquippedId { get => equippedWeapon.Id; }
    public WeaponData EquippedWeapon { get => equippedWeapon; }
    public int FlatDamage { get => equippedWeapon.FlatDamage; }
    public float MultiplierDamage { get => equippedWeapon.DamageMultiplier; }
    public IEnumerable<WeaponData> WeaponInventory { get => weaponInventory; }

    public Action OnEquipmentChange;

    public void EquipWeapon(WeaponData newWeapon)
    {
        changedWeapons.Clear();
        if (equippedWeapon != null)
        {
            equippedWeapon.Equipped = false;
            changedWeapons.Add(equippedWeapon);
        }
        changedWeapons.Add(newWeapon);
        newWeapon.Equipped = true;
        equippedWeapon = newWeapon;
        OnEquipmentChange?.Invoke();
        DataService.instance.UpdateWeaponDatas(changedWeapons);
    }

    public void PickupWeapon(WeaponData newWeapon)
    {
        changedWeapons.Clear();
        weaponInventory.Add(newWeapon);
        changedWeapons.Add(newWeapon);
        newWeapon.Id = DataService.instance.CreateWeaponData();
        newWeapon.PlayerId = playerStats.PlayerId;
        DataService.instance.UpdateWeaponData(newWeapon);
        OnEquipmentChange?.Invoke();
        DataService.instance.UpdateWeaponDatas(changedWeapons);
    }

    public void Initialize(IEnumerable<WeaponData> weaponDatas)
    {
        changedWeapons.Clear();
        weaponInventory = weaponDatas.ToList();
        equippedWeapon = weaponInventory.FirstOrDefault(wd => wd.Equipped);
        changedWeapons.Concat(weaponInventory);
        OnEquipmentChange?.Invoke();
    }

    public void RerollWeapons(IEnumerable<WeaponData> weaponDatas)
    {
        changedWeapons.Clear();
        foreach(WeaponData weapon in weaponDatas)
        {
            weapon.Reroll();
            changedWeapons.Add(weapon);
        }
        OnEquipmentChange?.Invoke();
        DataService.instance.UpdateWeaponDatas(changedWeapons);
    }
}
