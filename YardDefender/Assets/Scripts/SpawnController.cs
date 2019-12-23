using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] MobData mobData;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] MobStats mobStats;

    public void Initialize(MobData _mobData)
    {
        mobData = _mobData;
    }

    private void UpdateMob()
    {
        spriteRenderer.sprite = mobData.sprite;
        mobStats.Initialize(mobData);
    }

    private void OnValidate()
    {
        UpdateMob();
    }
}
