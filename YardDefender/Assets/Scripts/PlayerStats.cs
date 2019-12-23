using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    int playerId = 0;
    [SerializeField] int level = 1;
    [SerializeField] int experience = 0;
    [SerializeField] int damageLevel = 1;
    [SerializeField] int speedLevel = 1;

    public int PlayerId { get => playerId; }
    public int Level { get => level;}
    public int Experience { get => experience;}
    public int DamageLevel { get => damageLevel;}
    public int SpeedLevel { get => speedLevel;}

    public void Initialize(PlayerData playerData)
    {
        playerId = playerData.Id;
        level = playerData.Level;
        experience = playerData.Experience;
        damageLevel = playerData.DamageLevel;
        speedLevel = playerData.SpeedLevel;
    }

    public void IncreaseExperience(int exp)
    {
        experience += exp;
    }
}
