using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErikOverflow.YardDefender
{
    [CreateAssetMenu(fileName = "New Weapon Template", menuName = "Create New Weapon Template", order = 0)]
    public class WeaponTemplate : ScriptableObject
    {
        public int flatDamageMin, flatDamageMax;
        public float multiplierDamageMin, multiplierDamageMax;
        public int rerollCost;
    }
}