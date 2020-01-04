//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class DeathHandler : MonoBehaviour
//{
//    //[SerializeField] HealthController healthController = null;
//    [SerializeField] MobStats mobStats = null;
//    [SerializeField] AudioSource audioSource = null;
//    [SerializeField] Animator animator = null;
//    //Have an EnemyDetail script that has loot table and exp amount

//    void HandleDeath()
//    {
//        //healthController.LastAttacker?.KilledMob(mobStats);
//        throw new System.Exception("Have not implemented death handling yet");
//        //KillManager.instance.EnemyKilled(mobStats, healthController.LastAttacker);
//        audioSource.Play();
//        animator.SetBool("Alive", false);
//        StartCoroutine(DisableAfterAnimation());
//        //gameObject.SetActive(false);
//    }

//    IEnumerator DisableAfterAnimation()
//    {
//        yield return null;
//        while (!animator.GetCurrentAnimatorStateInfo(0).IsName("ZombieState"))
//        {
//            yield return null;
//        }
//        gameObject.SetActive(false);
//    }

//    void OnDestroy()
//    {
//        //healthController.OnDeath -= HandleDeath;
//    }
//}
