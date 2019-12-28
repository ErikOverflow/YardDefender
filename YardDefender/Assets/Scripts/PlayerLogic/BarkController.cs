using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerStats))]
public class BarkController : MonoBehaviour
{
    float barkSize = 1.0f;
    int barkDamage = 1;

#pragma warning disable 414
    [SerializeField]
    int touchNum = 2;

    [SerializeField]
    GameObject barkPrefab = null;

    bool active = false;
    PlayerStats playerStats = null;
    // Start is called before the first frame update
    void Awake()
    {
        playerStats = GetComponent<PlayerStats>();
#if UNITY_IOS || UNITY_ANDROID
        TouchManager.TouchInput += HandleTouch;
#endif
    }

    public void Initialize(float _barkSize, int _barkDamage)
    {
        barkSize = _barkSize;
        barkDamage = _barkDamage;
    }

    void HandleTouch(int fingerNum, Touch touch)
    {
        if (fingerNum != touchNum)
            return;
        if(touch.phase == TouchPhase.Began)
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
        bark.Initialize(barkDamage, barkSize, transform.position, playerStats);
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
