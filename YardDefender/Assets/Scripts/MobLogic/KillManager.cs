using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillManager : MonoBehaviour
{
    public static KillManager instance;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    public Action<MobStats, PlayerStats> OnKill;

    public void EnemyKilled(MobStats mobStats, PlayerStats playerStats)
    {
        OnKill?.Invoke(mobStats, playerStats);
    }
}
