using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErikOverflow.YardDefender
{
    public class MobLootController : MonoBehaviour
    {
        [SerializeField] MobInfo mobInfo = null;
        [SerializeField] GameObject itemDropPrefab = null;

        private void Awake()
        {
            EventManager.instance.OnMobKilled += DropItem;
        }

        void DropItem(MobInfo mob)
        {
            if (mobInfo != mob)
                return;
            if (mobInfo.ItemDrop != null)
            {
                GameObject go = ObjectPooler.instance.GetPooledObject(itemDropPrefab);
                go.transform.position = transform.position;
                ItemInfo itemInfo = go.GetComponent<ItemInfo>();
                itemInfo.SetItem(mobInfo.ItemDrop);
            }
        }
    }
}