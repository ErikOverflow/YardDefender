﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErikOverflow.YardDefender
{
    public class MobMovementInfo : MonoBehaviour
    {
        [SerializeField] Transform target = null;
        [SerializeField] float moveSpeed = 2f;
        [SerializeField] List<Spot> path = null;
        [SerializeField] MobInfo mobInfo = null;

        public Transform Target { get => target; }
        public float MoveSpeed { get => moveSpeed; }
        public List<Spot> Path { get => path; set => path = value; }

        void Start()
        {
            EventManager.Instance.OnMobKilled += RemoveTarget;
        }

        private void RemoveTarget(MobInfo mob)
        {
            if(mob == mobInfo)
            {
                target = null;
                path = null;
            }
        }

        public void SetTarget(Transform newTarget)
        {
            target = newTarget;
        }
    }
}