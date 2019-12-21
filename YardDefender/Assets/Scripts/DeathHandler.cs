using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    HealthController healthController = null;
    MobStats mobStats = null;
    //Have an EnemyDetail script that has loot table and exp amount

    void Awake()
    {
        healthController = GetComponent<HealthController>();
        mobStats = GetComponent<MobStats>();
        healthController.OnDeath += HandleDeath;
    }

    void HandleDeath()
    {
        ActiveGame.instance.IncreaseExperience(mobStats.Experience);
        Debug.Log("Kaput! Enemy died.");
    }

    void OnDestroy()
    {
        healthController.OnDeath -= HandleDeath;
    }
}
