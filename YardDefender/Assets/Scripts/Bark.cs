using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bark : MonoBehaviour
{
    int damage = 1;
    float barkStartingSize = 0.25f;
    float barkFinalSize = 3f;
    float barkTime = 1f;
    Vector3 barkPos = Vector3.zero;
    WaitForFixedUpdate waitForFixedUpdate = new WaitForFixedUpdate();

    public void Initialize(int _damage, float _barkStartingSize, float _barkFinalSize, float _barkTime, Vector3 _barkPos)
    {
        damage = _damage;
        barkStartingSize = _barkStartingSize;
        barkFinalSize = _barkFinalSize;
        barkTime = _barkTime;
        barkPos = _barkPos;
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
        transform.localScale = Vector3.one * barkStartingSize;
        yield return waitForFixedUpdate;
        while (time < barkTime)
        {
            time += Time.fixedDeltaTime;
            transform.localScale = Vector3.one * (barkStartingSize + time * (barkFinalSize - barkStartingSize) / barkTime);
            yield return waitForFixedUpdate;
        }
        transform.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HealthController hc = collision.GetComponent<HealthController>();
        hc?.TakeDamage(damage);
    }
}
