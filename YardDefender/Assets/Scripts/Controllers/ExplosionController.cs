using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErikOverflow.YardDefender
{
    public class ExplosionController : MonoBehaviour
    {
        [SerializeField] LevelInfo levelInfo = null;
        [SerializeField] ExplosionInfo explosionInfo = null;
        [SerializeField] Transform map = null;

        private void Start()
        {
            levelInfo.OnLevelChange += Activate;
        }

        public void Activate()
        {
            foreach(MobInfo mobInfo in map.GetComponentsInChildren<MobInfo>())
            {
                mobInfo.TakeDamage(explosionInfo.Damage, null);
            }
        }
    }
}