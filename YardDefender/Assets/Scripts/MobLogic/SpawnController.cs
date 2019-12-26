using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] MobData mobData;
    [SerializeField] SpriteRenderer spriteRenderer = null;
    [SerializeField] Animator animator = null;
    [SerializeField] MobStats mobStats = null;

    public void Initialize(MobData _mobData)
    {
        mobData = _mobData;
    }

    private void UpdateMob()
    {
        spriteRenderer.sprite = mobData.sprite;
        mobStats.Initialize(mobData);
        if(mobData.overrideController != null)
        {
            animator.runtimeAnimatorController = mobData.overrideController;
        }
    }

    private void OnValidate()
    {
        if (mobData == null)
            return;
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.sprite = mobData.sprite;
        mobStats.Initialize(mobData);
        if(mobData.overrideController != null)
        {
            animator.runtimeAnimatorController = mobData.overrideController;
        }
    }
}
