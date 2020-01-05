using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErikOverflow.YardDefender
{
    public class EquipmentInfo : MonoBehaviour
    {
        [SerializeField] GameInfo gameInfo = null;
        [SerializeField] EquipmentData equipmentData = null;

        public Action OnInfoChange;

        public EquipmentData EquipmentData { get => equipmentData; }
    }
}