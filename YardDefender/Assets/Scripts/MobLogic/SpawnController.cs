using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] MobData mobData;
    [SerializeField] SpriteRenderer spriteRenderer = null;
    [SerializeField] Animator animator = null;
    [SerializeField] MobStats mobStats = null;
    [SerializeField] HealthController healthController = null;

    public void Initialize(MobData _mobData)
    {
        mobData = _mobData;
        UpdateMob();
    }

    private void UpdateMob()
    {
        spriteRenderer.sprite = mobData.sprite;
        mobStats.Initialize(mobData);
        healthController.Initialize();
        if(mobData.overrideController != null)
        {
            animator.runtimeAnimatorController = mobData.overrideController;
        }
    }
}
