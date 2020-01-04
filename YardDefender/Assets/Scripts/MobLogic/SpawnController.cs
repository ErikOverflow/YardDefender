//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class SpawnController : MonoBehaviour
//{
//    [SerializeField] Mob mob;
//    [SerializeField] SpriteRenderer spriteRenderer = null;
//    [SerializeField] Animator animator = null;
//    [SerializeField] MobStats mobStats = null;
//    //[SerializeField] HealthController healthController = null;
//    //[SerializeField] LootController lootController = null;

//    //public void Initialize(Mob _mob)
//    //{
//    //    mob = _mob;
//    //    UpdateMob();
//    //}

//    private void UpdateMob()
//    {
//        spriteRenderer.sprite = mob.sprite;
//        mobStats.Initialize(mob);
//        //healthController.Initialize();
//        //lootController.Initialize(mob.weaponDrops);
//        if(mob.overrideController != null)
//        {
//            animator.runtimeAnimatorController = mob.overrideController;
//        }
//    }
//}
