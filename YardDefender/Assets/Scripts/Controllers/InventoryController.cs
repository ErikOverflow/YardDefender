using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErikOverflow.YardDefender
{
    public class InventoryController : MonoBehaviour
    {
        [SerializeField] InventoryInfo inventoryInfo = null;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            ItemInfo itemInfo = collision.GetComponent<ItemInfo>();
            if (itemInfo == null)
                return;
            inventoryInfo.AddItem(itemInfo.ItemData);
            itemInfo.gameObject.SetActive(false);
        }
    }
}