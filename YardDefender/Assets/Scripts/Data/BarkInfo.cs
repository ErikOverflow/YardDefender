﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErikOverflow.YardDefender
{
    public class BarkInfo : MonoBehaviour
    {
        int damage = 1;
        float barkFinalSize = 3f;
        private const float BarkTime = 0.2f;
        Vector3 barkPos = Vector3.zero;
        PlayerInfo barkInitiator = null;
        WaitForFixedUpdate waitForFixedUpdate = new WaitForFixedUpdate();

        public void Initialize(int _damage, float _barkFinalSize, Vector3 _barkPos, PlayerInfo _barkInitiatior)
        {
            damage = _damage;
            barkFinalSize = _barkFinalSize;
            barkPos = _barkPos;
            barkInitiator = _barkInitiatior;
        }

        public void Activate()
        {
            transform.gameObject.SetActive(true);
            transform.position = barkPos;
            StartCoroutine(Barking());
        }

        IEnumerator Barking()
        {
            float time = 0f;
            transform.localScale = Vector3.zero;
            yield return waitForFixedUpdate;
            while (time < BarkTime)
            {
                time += Time.fixedDeltaTime;
                if (time > BarkTime)
                    time = BarkTime;
                transform.localScale = Vector3.one * (time * (barkFinalSize) / BarkTime);
                yield return waitForFixedUpdate;
            }
            transform.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            MobInfo mobInfo = collision.GetComponent<MobInfo>();
            mobInfo?.TakeDamage(damage, barkInitiator);
        }
    }
}