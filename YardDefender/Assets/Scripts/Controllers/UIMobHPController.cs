using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ErikOverflow.YardDefender
{
    public class UIMobHPController : MonoBehaviour
    {
        [SerializeField] Slider slider = null;
        MobInfo trackedMob = null;
        Camera mainCam;
        void Awake()
        {
            EventManager.Instance.OnMobTookDamage += UpdateHealth;
            EventManager.Instance.OnMobKilled += MobKilled;
            mainCam = Camera.main;
        }

        private void MobKilled(MobInfo mobInfo)
        {
            if (mobInfo != trackedMob)
                return;
            trackedMob = null;
            gameObject.SetActive(false);
        }

        public void SetTrackedMob(MobInfo mobInfo)
        {
            trackedMob = mobInfo;
            if (mobInfo.CurrentHealth <= 0)
                MobKilled(mobInfo);
            slider.value = (float)mobInfo.CurrentHealth / mobInfo.MaxHealth;
            Vector3 pos = trackedMob.transform.position;
            pos.y -= 0.5f;
            transform.position = mainCam.WorldToScreenPoint(pos);
        }

        private void UpdateHealth(MobInfo mobInfo)
        {
            if (mobInfo != trackedMob)
                return;
            slider.value = (float)mobInfo.CurrentHealth / mobInfo.MaxHealth;
        }

        private void Update()
        {
            Vector3 pos = trackedMob.transform.position;
            pos.y -= 0.5f;
            transform.position = mainCam.WorldToScreenPoint(pos);
        }
    }
}