using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErikOverflow.YardDefender
{
    public class MobMovementController : MonoBehaviour
    {
        [SerializeField] MobMovementInfo mobMovementInfo = null;
        [SerializeField] Rigidbody2D rb2d = null;

        Coroutine activePathingCoroutine = null;
        WaitForFixedUpdate wffu = new WaitForFixedUpdate();

        private void Start()
        {
            mobMovementInfo.OnInfoChange += StartPathing;
            StartPathing();
        }

        void StartPathing()
        {
            if(activePathingCoroutine != null)
                StopCoroutine(activePathingCoroutine);
            if (mobMovementInfo.Target == null)
            {
                return;
            }
            activePathingCoroutine = StartCoroutine(PathTowards(mobMovementInfo.Target));
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
