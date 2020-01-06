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
        [SerializeField] GameObject itemDropPrefab = null;

        // Start is called before the fir st frame update
        void Start()
        {
            mobInfo.OnDeath += HandleDeath;
        }

        void HandleDeath()
        {
            deathAudioSource.Play();
            animator.SetBool("Alive", false);
            StartCoroutine(DisableAfterAnimation());
            mobInfo.LastDamageSource.ChangeExperience(mobInfo.Experience);
            mobInfo.LastDamageSource.ChangeGold(mobInfo.Gold);
            PortalInfo.instance.MobKilled();

            if (mobInfo.ItemDrop != null)
            {
                GameObject go = ObjectPooler.instance.GetPooledObject(itemDropPrefab);
                go.transform.position = transform.position;
                ItemInfo itemInfo = go.GetComponent<ItemInfo>();
                itemInfo.SetItem(mobInfo.ItemDrop);
            }
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