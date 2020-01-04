using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErikOverflow.YardDefender
{
    public class ItemInfo : MonoBehaviour
    {
        [SerializeField] GameInfo gameInfo = null;
        [SerializeField] IEnumerable<ItemData> itemDatas = null;

        public IEnumerable<ItemData> ItemDatas { get => itemDatas; }

        public Action OnInfoChange;

        // Start is called before the first frame update
        void Start()
        {
            gameInfo.OnInfoChange += LoadInventoryData;
            LoadInventoryData();
        }

        void LoadInventoryData()
        {
            itemDatas = DataService.instance.ReadRowsByGameId<ItemData>(gameInfo.SaveData.Id);
            OnInfoChange?.Invoke();
        }

        private void OnDestroy()
        {
            gameInfo.OnInfoChange -= LoadInventoryData;
        }
    }
}