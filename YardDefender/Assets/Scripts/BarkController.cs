using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    ActiveGame activeGame = ActiveGame.instance;
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
        bark.Initialize(CalculateBarkDamage(), CalculateBarkSize(), transform.position);
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
        return 1f / (DefaultAttackSpeed * activeGame.playerData.SpeedLevel);
    }

    int CalculateBarkDamage()
    {
        return activeGame.playerData.DamageLevel;
    }

    float CalculateBarkSize()
    {
        return DefaultBarkSize * Mathf.Pow(BarkSizeGrowth, activeGame.playerData.Level - 1);
    }
}
