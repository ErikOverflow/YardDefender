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
            portalInfo.OnInfoChange += ActivatePortal;
            mainCam = Camera.main;
            ActivatePortal();
        }

        private void ActivatePortal()
        {
            button.enabled = portalInfo.Active;
            if (portalInfo.Active)
                image.sprite = activeImage;
            else
                image.sprite = inactiveImage;
        }

        public void LevelUp()
        {
            levelInfo.ChangeLevel(portalInfo.LevelChange);
        }
    }
}