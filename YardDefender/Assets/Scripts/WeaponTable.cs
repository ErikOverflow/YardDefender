using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTable : MonoBehaviour
{
    public static WeaponTable instance;

    [SerializeField] Weapon[] allWeapons = null;
    Dictionary<string, Weapon> weaponDict = new Dictionary<string, Weapon>();

    public void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        else
        {
            foreach(Weapon wd in allWeapons)
            {
                if (weaponDict.ContainsKey(wd.name))
                    continue;
                weaponDict.Add(wd.name, wd);
            }
            instance = this;
        }
    }

    public Weapon GetWeapon(string weaponName)
    {
        if (string.IsNullOrEmpty(weaponName))
            return null;
        Weapon weapon;
        weaponDict.TryGetValue(weaponName, out weapon);
        return weapon;
    }
}

public class WeaponNotInGlobalTableException : Exception
{
    public WeaponNotInGlobalTableException(string message) : base(message) { }
}
