﻿
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MobSpawner : MonoBehaviour
{
    [SerializeField] GameObject mobPrefab = null;
    [SerializeField] List<MobRecord> mobTable = null;
    [SerializeField] int mobCount = 1;
    [SerializeField] Transform target = null;

    int totalWeight = 0;

    WaitForSeconds wfs = new WaitForSeconds(1);

    [Serializable]
    public struct MobRecord
    {
        public MobData mobData;
        public int weight;
    }

    private void Start()
    {
        totalWeight = 0;
        foreach(MobRecord mobRecord in mobTable)
        {
            totalWeight += mobRecord.weight;
        }
        StartCoroutine(TimedSpawner());
    }

    IEnumerator TimedSpawner()
    {
        for (int i = 0; i < mobCount; i++)
        {
            int mobSelection = Random.Range(0, totalWeight);

            // #1: 1
            // #2: 1
            // #3: 1
            //Random number can be anywhere from 0 - 2
            // mobSelection -= weight. If less than 0, then that mob is selected. 
            foreach (MobRecord mr in mobTable)
            {
                mobSelection -= mr.weight;
                if (mobSelection < 0)
                {
                    SpawnMob(mr);
                    break;
                }
            }

            yield return wfs;
        }
    }

    private void SpawnMob(MobRecord mobrecord)
    {
        GameObject go = Instantiate(mobPrefab, transform);
        go.transform.localPosition = Vector3.zero;
        SpawnController sc = go.GetComponent<SpawnController>();
        sc.Initialize(mobrecord.mobData);
        MobMovement mm = go.GetComponent<MobMovement>();
        mm.StartPathing(target);
    }
}