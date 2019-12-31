using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class LootWeapon : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer = null;
    WeaponData weaponData = null;

    WaitForSeconds wfs = new WaitForSeconds(0.3f);

    public void Initialize(Weapon weapon)
    {
        weaponData = new WeaponData
        {
            Name = weapon.name,
            //We add 1 to the max because it is an exclusive random 
            FlatDamage = Random.Range(weapon.flatDamageMin, weapon.flatDamageMax + 1),
            DamageMultiplier = Random.Range(weapon.multiplierDamageMin, weapon.multiplierDamageMax)
        };
        spriteRenderer.sprite = weaponData.Sprite;
    }

    IEnumerator DelayPickup(PlayerEquipment playerEquipment)
    {
        yield return wfs;
        if (playerEquipment != null)
        {
            playerEquipment.PickupWeapon(weaponData);
        }
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerEquipment playerEquipment = collision.GetComponent<PlayerEquipment>();
        StartCoroutine(DelayPickup(playerEquipment));
    }
}
