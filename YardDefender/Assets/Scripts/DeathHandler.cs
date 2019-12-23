using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    HealthController healthController = null;
    MobStats mobStats = null;
    AudioSource audioSource = null;
    Animator animator = null;
    //Have an EnemyDetail script that has loot table and exp amount

    void Awake()
    {
        healthController = GetComponent<HealthController>();
        mobStats = GetComponent<MobStats>();
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        healthController.OnDeath += HandleDeath;
    }

    void HandleDeath()
    {
        healthController.LastAttacker?.IncreaseExperience(mobStats.Experience);
        audioSource.Play();
        animator.SetBool("Alive", false);
        StartCoroutine(DisableAfterAnimation());
        //gameObject.SetActive(false);
    }

    IEnumerator DisableAfterAnimation()
    {
        yield return null;
        while (!animator.GetCurrentAnimatorStateInfo(0).IsName("ZombieState"))
        {
            yield return null;
        }
        gameObject.SetActive(false);
    }

    void OnDestroy()
    {
        healthController.OnDeath -= HandleDeath;
    }
}
