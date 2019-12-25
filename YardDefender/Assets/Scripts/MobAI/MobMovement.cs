using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MobMovement : MonoBehaviour
{
    [SerializeField] Transform target = null;
    public float moveSpeed = 2f; //Spots per second moved

    Rigidbody2D rb2d;
    List<Spot> path = null;

    WaitForFixedUpdate wffu = new WaitForFixedUpdate();

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartPathing();
    }

    public void StartPathing()
    {
        path = GridManager.instance.GetPath(transform.position, target.position);        
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
                rb2d.MovePosition(Vector2.Lerp(startPos, destPos, timer * moveSpeed));
                yield return wffu;
                timer += Time.fixedDeltaTime;
            }
            timer = timer % (1 / moveSpeed);
        }
    }
}
