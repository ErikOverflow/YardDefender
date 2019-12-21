using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobStats : MonoBehaviour
{
    [SerializeField] int baseHealth = 10;
    [SerializeField] int experience = 1;

    public int BaseHealth { get => baseHealth;}
    public int Experience { get => experience;}    
}
