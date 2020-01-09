using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ErikOverflow.YardDefender
{
    public class PortalController : MonoBehaviour
    {
        [SerializeField] LevelInfo levelInfo = null;
        [SerializeField] PortalInfo portalInfo = null;
        [SerializeField] Button button = null;
        [SerializeField] Image image = null;

        [SerializeField] Sprite activeButtonImage = null;
        [SerializeField] Sprite inactiveButtonImage = null;

        
        private void Awake()
        {
            EventManager.instance.OnLevelStarted += InitializePortal;
            EventManager.instance.OnLevelDefeated += OpenPortal;
        }

        private void InitializePortal()
        {
            button.enabled = false;
            image.sprite = inactiveButtonImage;
        }

        private void OpenPortal(LevelInfo _levelInfo)
        {
            button.enabled = true;
            image.sprite = activeButtonImage;
        }

        public void LevelUp()
        {
            levelInfo.ChangeLevel(portalInfo.NextLevel);
        }
    }
}
