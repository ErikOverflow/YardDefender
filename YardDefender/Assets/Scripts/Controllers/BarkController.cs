﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErikOverflow.YardDefender
{
    public class BarkController : MonoBehaviour
    {
#pragma warning disable 414
        [SerializeField] int touchNum = 2;
        [SerializeField] PlayerInfo playerInfo = null;
        [SerializeField] GameObject barkPrefab = null;

        bool active = false;

        // Start is called before the first frame update
        void Awake()
        {
#if UNITY_IOS || UNITY_ANDROID
        TouchManager.TouchInput += HandleTouch;
#endif
        }

        void HandleTouch(int fingerNum, Touch touch)
        {
            if (fingerNum != touchNum)
                return;
            if (touch.phase == TouchPhase.Began)
                StartCoroutine(Bark());
        }

#if !UNITY_IOS && !UNITY_ANDROID
        void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                StartCoroutine(Bark());
            }
        }
#endif

        IEnumerator Bark()
        {
            if (active)
                yield break;
            active = true;
            GameObject barkObj = ObjectPooler.instance.GetPooledObject(barkPrefab);
            BarkInfo bark = barkObj.GetComponent<BarkInfo>();
            bark.Initialize(playerInfo.Attack, playerInfo.BarkSize, transform.position, playerInfo);
            bark.Activate();
            yield return null;
            active = false;
        }

#if UNITY_IOS || UNITY_ANDROID
    void OnDestroy()
    {
        TouchManager.TouchInput -= HandleTouch;
    }
#endif
    }
}