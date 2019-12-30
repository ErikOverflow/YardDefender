using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{
    [SerializeField] int flatDamage = 0;
    [SerializeField] float multiplierDamage = 1.0f;


    //Can reroll all stats with gold
    //Can prestige weapons with gold after a certain number of kills with the weapon. Prestige unlocks special ability.
    //Drops from enemies, with a minimum of 1% before it can drop (requiring higher difficulty levels to get some items)

    public int FlatDamage { get => flatDamage; }
    public float MultiplierDamage { get => multiplierDamage; }

    public Action OnEquipmentChange;

    public void EquipWeapon()
    {
        OnEquipmentChange?.Invoke();
    }

    public void EquipArmor()
    {
        OnEquipmentChange?.Invoke();
    }
}
