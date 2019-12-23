using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobStats : MonoBehaviour
{
    int level = 1;
    [SerializeField] int baseHealth = 10;
    [SerializeField] int baseExperience = 1;

    public void Initialize(MobData mobData)
    {
        baseHealth = mobData.baseHealth;
        baseExperience = mobData.baseExperience;
    }

    public int BaseHealth { get => baseHealth * level;}
    public int Experience { get => baseExperience * level;}
}
