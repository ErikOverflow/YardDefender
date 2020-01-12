using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErikOverflow.YardDefender
{
    public class UIEventsController : MonoBehaviour
    {
        [SerializeField] GameObject hpPrefab = null;

        void Awake()
        {
            EventManager.instance.OnMobSpawned += MobSpawned;
        }

        private void MobSpawned(MobInfo mobInfo)
        {
            GameObject go = ObjectPooler.instance.GetPooledObject(hpPrefab);
            UIMobHPController uimhp = go.GetComponent<UIMobHPController>();
            uimhp.SetTrackedMob(mobInfo);
            go.transform.SetParent(this.transform);
        }

        private void OnDestroy()
        {
            EventManager.instance.OnMobSpawned -= MobSpawned;
        }
    }
}