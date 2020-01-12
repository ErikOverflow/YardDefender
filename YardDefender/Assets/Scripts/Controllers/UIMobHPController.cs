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
        // Start is called before the first frame update
        void Awake()
        {
            EventManager.instance.OnMobTookDamage += UpdateHealth;
            EventManager.instance.OnMobKilled += MobKilled;
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
            slider.value = (float)mobInfo.CurrentHealth / mobInfo.MaxHealth;
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