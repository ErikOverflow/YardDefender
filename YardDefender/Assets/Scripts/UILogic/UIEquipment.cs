//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using TMPro;
//using UnityEngine;
//using UnityEngine.UI;

//public class UIEquipment : MonoBehaviour
//{
//    [SerializeField] PlayerEquipment playerEquipment = null;
//    [SerializeField] Image equippedWeaponImage = null;
//    [SerializeField] TextMeshProUGUI rerollCost = null;
//    [SerializeField] TextMeshProUGUI flatDamage = null;
//    [SerializeField] TextMeshProUGUI damageMultiplier = null;
//    [SerializeField] GameObject weaponSlotPrefab = null;
//    [SerializeField] Transform inventoryContent = null;

//    // Start is called before the first frame update
//    void Awake()
//    {
//        playerEquipment.OnEquipmentChange += RenderEquipment;
//    }

//    public void RenderEquipment()
//    {
//        foreach (Transform child in inventoryContent)
//        {
//            child.gameObject.SetActive(false);
//        }
//        foreach (WeaponData weaponData in playerEquipment.WeaponInventory.OrderBy(w=> w.Id))
//        {
//            if (weaponData.Equipped)
//            {
//                equippedWeaponImage.sprite = weaponData.Sprite;
//                rerollCost.text = weaponData.RerollCost.ToString();
//                flatDamage.text = weaponData.FlatDamage.ToString();
//                damageMultiplier.text = string.Format("{0}%", weaponData.DamageMultiplier);
//                continue;
//            }
//            GameObject go = ObjectPooler.instance.GetPooledObject(weaponSlotPrefab);
//            go.transform.SetParent(inventoryContent);
//            UIWeaponSlot weaponSlot = go.GetComponent<UIWeaponSlot>();
//            weaponSlot.RenderWeapon(weaponData, playerEquipment);
//            //Put it in the inventory section;
//        }
//    }

//    public void RerollEquippedWeapon()
//    {
//        playerEquipment.RerollWeapons(IEnumerableExt.FromSingleItem<WeaponData>(playerEquipment.EquippedWeapon));
//    }

//    private void OnDestroy()
//    {
//        playerEquipment.OnEquipmentChange -= RenderEquipment;
//    }
//}
