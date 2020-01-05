using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErikOverflow.YardDefender
{
    public class ItemInfo : MonoBehaviour
    {
        [SerializeField] SpriteRenderer spriteRenderer = null;
        ItemData itemData = null;

        public ItemData ItemData { get => itemData; }

        // Start is called before the first frame update
        void Start()
        {
            ItemData _itemData = new WeaponData
            {
                Name = "Megaphone",
                Multiplier = 1.4f,
                Damage = 5,
                Guid = "38c45551-d75f-458b-b420-30e1253ee27d"
            };
            SetItem(_itemData);
        }

        public void SetItem(ItemData _itemData)
        {
            itemData = _itemData;
            ItemTemplate itemTemplate;
            ItemDictionary.Instance.TryGetValue(itemData.Guid, out itemTemplate);
            spriteRenderer.sprite = itemTemplate.sprite;
        }
    }
}