using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    int damage = 1;
    [SerializeField]
    float barkStartingSize = 0.25f;
    [SerializeField]
    float barkSize = 3;
    [SerializeField]
    float barkTime = 1;
    [SerializeField]
    float barkDelay = 0.25f;

    public int Damage
    {
        get
        {
            return damage;
        }
    }
    public float BarkStartingSize
    {
        get
        {
            return barkStartingSize;
        }
    }
    public float BarkSize
    {
        get
        {
            return barkSize;
        }
    }
    public float BarkTime
    {
        get
        {
            return barkTime;
        }
    }
    public float BarkDelay
    {
        get
        {
            return barkDelay;
        }
    }
}
