using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErikOverflow.YardDefender
{
    [CreateAssetMenu(fileName = "New Weapon Template", menuName = "Create New Weapon Template", order = 0)]
    public class WeaponTemplate : ItemTemplate
    {
        public int flatDamageMin, flatDamageMax;
        public float multiplierDamageMin, multiplierDamageMax;
        public int rerollCost;

        public WeaponData RollForWeapon()
        {
            WeaponData weaponData = new WeaponData
            {
                Damage = Random.Range(flatDamageMin, flatDamageMax),
                Multiplier = Random.Range(multiplierDamageMin, multiplierDamageMax),
                Name = name,
                Guid = itemId
            };
            return weaponData;
        }
    }
}
