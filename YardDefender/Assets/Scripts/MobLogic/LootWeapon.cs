//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//[RequireComponent(typeof(Collider2D))]
//public class LootWeapon : MonoBehaviour
//{
//    [SerializeField] SpriteRenderer spriteRenderer = null;
//    WeaponData weaponData = null;

//    public void Initialize(Weapon weapon)
//    {
//        weaponData = new WeaponData
//        {
//            Name = weapon.name,
//            //We add 1 to the max because it is an exclusive random 
//            FlatDamage = Random.Range(weapon.flatDamageMin, weapon.flatDamageMax + 1),
//            DamageMultiplier = Random.Range(weapon.multiplierDamageMin, weapon.multiplierDamageMax)
//        };
//        spriteRenderer.sprite = weaponData.Sprite;
//    }

//    private void OnTriggerEnter2D(Collider2D collision)
//    {
//        PlayerEquipment playerEquipment = collision.GetComponent<PlayerEquipment>();
//        if (playerEquipment != null)
//        {
//            playerEquipment.PickupWeapon(weaponData);
//        }
//        gameObject.SetActive(false);
//    }
//}
