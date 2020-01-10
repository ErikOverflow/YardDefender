using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErikOverflow.YardDefender
{
    public class ItemDictionary : MonoBehaviour
    {
        [SerializeField] ItemTable itemTable = null;

        static Dictionary<int, ItemTemplate> instance;

        public static Dictionary<int, ItemTemplate> Instance { get => instance; }

        private void Awake()
        {
            instance = new Dictionary<int, ItemTemplate>();
            foreach (ItemTemplate itemTemplate in itemTable.itemTemplates)
            {
                instance.Add(itemTemplate.itemId, itemTemplate);
            }
        }
    }
}