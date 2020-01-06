using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErikOverflow.YardDefender
{
    public class UIItemSlotInfo : MonoBehaviour
    {
        [SerializeField] ItemData itemData = null;
        [SerializeField] EquipmentInfo equipmentInfo = null;

        public ItemData ItemData { get => itemData; }
        public EquipmentInfo EquipmentInfo { get => equipmentInfo; }

        public Action OnInfoChanged;

        public void Initialize(ItemData _itemData, EquipmentInfo _equipmentInfo)
        {
            itemData = _itemData;
            equipmentInfo = _equipmentInfo;
            OnInfoChanged?.Invoke();
        }
    }
}