﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ErikOverflow.YardDefender
{
    public class UIItemSlotController : MonoBehaviour
    {
        [SerializeField] Image image = null;
        [SerializeField] UIItemSlotInfo uIItemSlotInfo = null;

        private void Start()
        {
            uIItemSlotInfo.OnInfoChanged += UpdateSlot;
            UpdateSlot();
        }

        private void UpdateSlot()
        {
            ItemTemplate itemTemplate;
            ItemDictionary.Instance.TryGetValue(uIItemSlotInfo.ItemData.Guid, out itemTemplate);
            image.sprite = itemTemplate.sprite;
        }

        public void UseItem()
        {
            EventManager.Instance.UseItem(uIItemSlotInfo.ItemData);
        }

        private void OnDestroy()
        {
            uIItemSlotInfo.OnInfoChanged -= UpdateSlot;
        }
    }
}