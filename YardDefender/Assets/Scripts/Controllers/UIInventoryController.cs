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
        void Awake()
        {
            EventManager.Instance.OnPlayerEquipmentChanged += ReloadEquipment;
            EventManager.Instance.OnInventoryChanged += ReloadInventory;
        }

        private void Start()
        {
            ReloadInventory();
            ReloadEquipment();
        }

        void ReloadInventory()
        {
            foreach(Transform child in inventoryContent)
            {
                child.gameObject.SetActive(false);
            }
            foreach(ItemData itemData in inventoryInfo.ItemDatas)
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
                equippedWeaponImage.sprite = default;
                rerollCost.text = "---";
                flatDamageText.text = "---";
                multiplierText.text = "---";
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
                    rerollCost.text = "---";
                }
                flatDamageText.text = weaponData.Damage.ToString();
                multiplierText.text = weaponData.Multiplier.ToString("G4");
            }
        }

        public void UnEquipWeapon()
        {
            equipmentInfo.UnEquipWeapon();
        }
    }
}