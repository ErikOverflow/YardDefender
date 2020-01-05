using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErikOverflow.YardDefender
{
    public class UIInventoryController : MonoBehaviour
    {
        [SerializeField] InventoryInfo inventoryInfo = null;
        [SerializeField] EquipmentInfo equipmentInfo = null;
        [SerializeField] GameObject inventorySlotPrefab = null;
        [SerializeField] Transform inventoryContent = null;


        // Start is called before the first frame update
        void Start()
        {
            inventoryInfo.OnInfoChange += ReloadInventory;
            equipmentInfo.OnInfoChange += ReloadInventory;
            ReloadInventory();
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
                uIItemSlotInfo.Initialize(itemData);
            }
        }
    }
}