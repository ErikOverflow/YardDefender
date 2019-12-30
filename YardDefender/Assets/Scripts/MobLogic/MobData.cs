using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Mob", menuName = "Create New Enemy", order = 0)]
public class MobData : ScriptableObject
{
    public Sprite sprite;
    public int baseHealth;
    public int baseExperience;
    public int baseGold;
    public AnimatorOverrideController overrideController;
    public List<WeaponDrop> weaponDrops;
}

[Serializable]
public struct WeaponDrop
{
    public float dropChance;
    public Weapon weapon;
}