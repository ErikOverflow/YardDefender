using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobStats : MonoBehaviour
{
    [SerializeField] int baseHealth;
    [SerializeField] int experience;

    public int BaseHealth { get => baseHealth;}
    public int Experience { get => experience;}    
}
