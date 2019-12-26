using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    [SerializeField] GameObject mobPrefab = null;
    [SerializeField] List<MobRecord> mobTable = null;
    [SerializeField] Transform target = null;

    [Serializable]
    public struct MobRecord
    {
        public MobData mobData;
        public int weight;
    }

    private void Start()
    {
        StartCoroutine(TimedSpawner());
    }

    IEnumerator TimedSpawner()
    {
        for (int i = 0; i < 3; i++)
        {
            foreach (MobRecord mr in mobTable)
            {
                SpawnMob(mr);
                yield return new WaitForSeconds(1);
            }
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
