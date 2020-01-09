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

        [SerializeField] Sprite activeImage = null;
        [SerializeField] Sprite inactiveImage = null;

        private void Awake()
        {
            EventManager.Instance.OnLevelStarted += InitializePortal;
            EventManager.Instance.OnLevelDefeated += OpenPortal;
        }

        private void InitializePortal()
        {
            button.enabled = false;
            image.sprite = inactiveImage;
        }

        private void OpenPortal(LevelInfo _levelInfo)
        {
            button.enabled = true;
            image.sprite = activeImage;
        }

        public void LevelUp()
        {
            levelInfo.ChangeLevel(portalInfo.NextLevel);
        }
    }
}