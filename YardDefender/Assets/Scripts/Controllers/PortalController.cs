using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ErikOverflow.YardDefender
{
    public class PortalController : MonoBehaviour
    {
        [SerializeField] PortalInfo portalInfo = null;
        [SerializeField] LevelInfo levelInfo = null;
        [SerializeField] Button button = null;
        [SerializeField] Image image = null;

        [SerializeField] Sprite activeImage = null;
        [SerializeField] Sprite inactiveImage = null;

        Camera mainCam = null;

        private void Start()
        {
            EventManager.Instance.OnLevelChanged += InitializePortal;
            //On level completed, open portal
            mainCam = Camera.main;
        }

        private void InitializePortal()
        {
            button.enabled = false;
            image.sprite = inactiveImage;
        }

        private void OpenPortal()
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