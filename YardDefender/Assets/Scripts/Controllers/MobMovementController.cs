using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErikOverflow.YardDefender
{
    public class MobMovementController : MonoBehaviour
    {
        [SerializeField] MobMovementInfo mobMovementInfo = null;
        [SerializeField] MobInfo mobInfo = null;
        [SerializeField] Rigidbody2D rb2d = null;

        Coroutine activePathing = null;
        WaitForFixedUpdate wffu = new WaitForFixedUpdate();

        private void Start()
        {
            EventManager.Instance.OnMobKilled += StopPathing;
            EventManager.Instance.OnMobSpawned += StartPathing;
        }

        private void StopPathing(MobInfo mob)
        {
            if (mobInfo != mob)
                return;
            if (activePathing != null)
                StopCoroutine(activePathing);
        }

        void StartPathing(MobInfo mob)
        {
            if (mobInfo != mob)
                return;
            if (mobMovementInfo.Target == null)
            {
                return;
            }
            if (activePathing != null)
                StopCoroutine(activePathing);
            activePathing = StartCoroutine(PathTowards(mobMovementInfo.Target));
        }

        IEnumerator PathTowards(Transform target)
        {
            mobMovementInfo.Path = GridManager.instance.GetPath(transform.position, target.position);
            float timer = 0f;
            foreach (Spot spot in mobMovementInfo.Path)
            {
                Vector2 startPos = transform.position;
                Vector2 destPos = GridManager.instance.GetSpotWorldPosition(spot);
                while (timer < 1 / mobMovementInfo.MoveSpeed)
                {
                    rb2d.MovePosition(Vector2.Lerp(startPos, destPos, timer * mobMovementInfo.MoveSpeed));
                    yield return wffu;
                    timer += Time.fixedDeltaTime;
                }
                timer = timer % (1 / mobMovementInfo.MoveSpeed);
            }
        }
    }
}
