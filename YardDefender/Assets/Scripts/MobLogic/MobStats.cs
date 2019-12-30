using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobStats : MonoBehaviour
{
    [SerializeField] int health = 10;
    [SerializeField] int experience = 1;
    [SerializeField] int gold = 5;

    public void Initialize(MobData mobData)
    {
        health = mobData.baseHealth;
        experience = mobData.baseExperience;
        gold = mobData.baseGold;
    }

    public int Health { get => health; }
    public int Experience { get => experience; }
    public int Gold { get => gold; }
}
