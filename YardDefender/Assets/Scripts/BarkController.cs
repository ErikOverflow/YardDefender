using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerStats))]
public class BarkController : MonoBehaviour
{
    private const float DefaultAttackSpeed = 0.5f; //Number of attacks per second
    private const float DefaultBarkSize = 2f;
    private const float BarkSizeGrowth = 1.1f; //Percentage increase in size per level

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
        bark.Initialize(CalculateBarkDamage(), CalculateBarkSize(), transform.position, playerStats);
        bark.Activate();
        yield return new WaitForSeconds(CalculateBarkDelay());
        active = false;
    }

#if UNITY_IOS || UNITY_ANDROID
    void OnDestroy()
    {
        TouchManager.TouchInput -= HandleTouch;
    }
#endif

    float CalculateBarkDelay()
    {
        return 1f / (DefaultAttackSpeed * playerStats.SpeedLevel);
    }

    int CalculateBarkDamage()
    {
        return playerStats.DamageLevel;
    }

    float CalculateBarkSize()
    {
        return DefaultBarkSize * Mathf.Pow(BarkSizeGrowth, playerStats.Level - 1);
    }
}
