using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Weapon", menuName = "Create New Weapon", order = 1)]
public class Weapon : ScriptableObject
{
    public Sprite sprite;
    public int flatDamageMin, flatDamageMax;
    public float multiplierDamageMin, multiplierDamageMax;
    public int rerollCost;
}
