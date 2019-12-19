using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    HealthController hc = null;
    //Have an EnemyDetail script that has loot table and exp amount

    void Awake()
    {
        hc = GetComponent<HealthController>();
        hc.OnDeath += HandleDeath;
    }

    void HandleDeath()
    {
        Debug.Log("Kaput! Enemy died.");
    }
}
