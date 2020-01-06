using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErikOverflow.YardDefender
{
    public class PortalController : MonoBehaviour
    {
        [SerializeField] PortalInfo portalInfo = null;
        [SerializeField] LevelInfo levelInfo = null;
        [SerializeField] SpriteRenderer spriteRenderer = null;
        [SerializeField] new Collider2D collider2D = null;

        private void Start()
        {
            portalInfo.OnInfoChange += ActivatePortal;
            ActivatePortal();
        }

        private void ActivatePortal()
        {
            spriteRenderer.enabled = portalInfo.Active;
            collider2D.enabled = portalInfo.Active;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.GetComponent<PlayerInfo>() != null)
            {
                levelInfo.ChangeLevel(portalInfo.LevelChange);
            }
        }
    }
}