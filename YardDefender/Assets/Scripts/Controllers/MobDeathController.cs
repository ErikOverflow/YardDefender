using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErikOverflow.YardDefender
{
    public class MobDeathController : MonoBehaviour
    {
        [SerializeField] MobInfo mobInfo = null;
        [SerializeField] Animator animator = null;
        [SerializeField] AudioSource deathAudioSource = null;

        void Awake()
        {
            EventManager.Instance.OnMobKilled += HandleDeath;
        }

        void HandleDeath(MobInfo mob)
        {
            if (mobInfo != mob)
                return;
            deathAudioSource.Play();
            animator.SetBool("Alive", false);
            StartCoroutine(DisableAfterAnimation());
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
    }
}