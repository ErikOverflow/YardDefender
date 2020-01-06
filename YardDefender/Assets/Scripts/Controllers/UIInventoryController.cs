using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ErikOverflow.YardDefender
{
    public class UIInventoryController : MonoBehaviour
    {
        [SerializeField] InventoryInfo inventoryInfo = null;
        [SerializeField] EquipmentInfo equipmentInfo = null;
        [SerializeField] GameObject inventorySlotPrefab = null;
        [SerializeField] Transform inventoryContent = null;

        [SerializeField] Image equippedWeaponImage = null;
        [SerializeField] TextMeshProUGUI rerollCost = null;
        [SerializeField] TextMeshProUGUI flatDamageText = null;
        [SerializeField] TextMeshProUGUI multiplierText = null;


        // Start is called before the first frame update
        void Start()
        {
            inventoryInfo.OnInfoChange += ReloadInventory;
            equipmentInfo.OnInfoChange += ReloadEquipment;
            ReloadInventory();
            ReloadEquipment();
        }

        void ReloadInventory()
        {
            foreach(Transform child in inventoryContent)
            {
                child.gameObject.SetActive(false);
            }
            foreach(ItemData itemData in inventoryInfo.AllItemDatas)
            {
                GameObject go = ObjectPooler.instance.GetPooledObject(inventorySlotPrefab);
                go.transform.SetParent(inventoryContent);
                go.transform.localScale = Vector3.one;
                UIItemSlotInfo uIItemSlotInfo = go.GetComponent<UIItemSlotInfo>();
                uIItemSlotInfo.Initialize(itemData, equipmentInfo);
            }
        }

        void ReloadEquipment()
        {
            WeaponData weaponData = equipmentInfo.WeaponData;
            if(weaponData == null)
            {
                //Zero out fields
            }
            else
            {
                ItemTemplate itemTemplate;
                ItemDictionary.Instance.TryGetValue(weaponData.Guid, out itemTemplate);
                if(itemTemplate is WeaponTemplate weaponTemplate)
                {
                    equippedWeaponImage.sprite = weaponTemplate.sprite;
                    rerollCost.text = weaponTemplate.rerollCost.ToString();
                }
                else
                {
                    //no reroll cost
                }
                flatDamageText.text = weaponData.Damage.ToString();
                multiplierText.text = weaponData.Multiplier.ToString("G4");
            }
        }
    }
}