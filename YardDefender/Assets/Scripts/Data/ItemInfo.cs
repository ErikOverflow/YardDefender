﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErikOverflow.YardDefender
{
    public class ItemInfo : MonoBehaviour
    {
        [SerializeField] SpriteRenderer spriteRenderer = null;
        [SerializeField] ItemTemplate itemTemplate = null;
        ItemData itemData = null;

        public ItemData ItemData { get => itemData; }

        public void SetItem(ItemData _itemData)
        {
            Debug.Log(_itemData.Name);
            itemData = _itemData;
            Debug.Log(itemData.Guid);
            ItemDictionary.Instance.TryGetValue(itemData.Guid, out itemTemplate);
            spriteRenderer.sprite = itemTemplate.sprite;
        }
    }
}