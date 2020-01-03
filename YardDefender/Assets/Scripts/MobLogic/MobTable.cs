using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Mob Table", menuName = "Create New Mob Table", order = 0)]
public class MobTable : ScriptableObject
{
    public int levelNum = 1;
    public List<MobRecord> mobs;
}

[Serializable]
public struct MobRecord
{
    public Mob mob;
    public int weight;
}

