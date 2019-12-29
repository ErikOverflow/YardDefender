using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MobMovement : MonoBehaviour
{
    Transform target = null;
    [SerializeField] Rigidbody2D rb2d = null;
    [SerializeField] HealthController healthController = null;
    public float moveSpeed = 2f; //Spots per second moved

    List<Spot> path = null;

    WaitForFixedUpdate wffu = new WaitForFixedUpdate();

    // Start is called before the first frame update

    public void StartPathing(Transform newTarget)
    {
        target = newTarget;
        path = GridManager.instance.GetPath(transform.position, newTarget.position);        
        StartCoroutine(Pathing());
    }

    IEnumerator Pathing()
    {
        float timer = 0f;
        foreach(Spot spot in path)
        {
            Vector2 startPos = transform.position;
            Vector2 destPos = GridManager.instance.GetSpotWorldPosition(spot);
            while(timer < 1 / moveSpeed)
            {
                if (!healthController.Alive)
                    yield break;
                rb2d.MovePosition(Vector2.Lerp(startPos, destPos, timer * moveSpeed));
                yield return wffu;
                timer += Time.fixedDeltaTime;
            }
            timer = timer % (1 / moveSpeed);
        }
    }
}
