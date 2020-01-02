﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Table", menuName = "Create New Weapon Table", order = 1)]
public class GlobalWeaponTable : ScriptableObject
{
    public Weapon[] weapons;
}
