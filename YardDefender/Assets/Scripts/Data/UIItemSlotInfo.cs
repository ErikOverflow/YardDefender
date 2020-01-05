using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErikOverflow.YardDefender
{
    public class UIItemSlotInfo : MonoBehaviour
    {
        [SerializeField] ItemData itemData = null;

        public ItemData ItemData { get => itemData; }

        public Action OnInfoChanged;

        public void Initialize(ItemData _itemData)
        {
            itemData = _itemData;
            OnInfoChanged?.Invoke();
        }
    }
}