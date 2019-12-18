using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarkController : MonoBehaviour
{
#pragma warning disable 414
    [SerializeField]
    int touchNum = 2;

    [SerializeField]
    PlayerStats playerStats = null;

    [SerializeField]
    GameObject barkPrefab = null;

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
        Bark bark = barkObj.GetComponent<Bark>();
        bark.Initialize(playerStats.Damage, playerStats.BarkStartingSize, playerStats.BarkSize, playerStats.BarkTime, transform.position);
        bark.Activate();
        yield return new WaitForSeconds(playerStats.BarkDelay);
        active = false;
    }

#if UNITY_IOS || UNITY_ANDROID
    void OnDestroy()
    {
        TouchManager.TouchInput -= HandleTouch;
    }
#endif
}
