using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private const float DefaultAttackSpeed = 0.5f; //Number of attacks per second
    private const float DefaultBarkSize = 2f;
    private const float BarkSizeGrowth = 1.1f; //Percentage increase in size per level

    int playerId = 0;
    [SerializeField] int gold = 0;
    [SerializeField] int level = 1;
    [SerializeField] int experience = 0;
    [SerializeField] int attackLevel = 1;
    [SerializeField] int speedLevel = 1;
    [SerializeField] BarkController barkController = null;

    public int PlayerId { get => playerId; }
    public int Gold { get => gold; }
    public int Level { get => level;}
    public int Experience { get => experience;}
    public int AttackLevel { get => attackLevel;}
    public int SpeedLevel { get => speedLevel;}

    public Action OnStatChange;

    private void Start()
    {
        ReInitialize();
    }

    public void Initialize(PlayerData playerData)
    {
        playerId = playerData.Id;
        level = playerData.Level;
        experience = playerData.Experience;
        attackLevel = playerData.DamageLevel;
        speedLevel = playerData.SpeedLevel;
        ReInitialize();
    }

    public void ReInitialize()
    {
        barkController.Initialize(
            DefaultBarkSize * Mathf.Pow(BarkSizeGrowth, Level - 1), //Attack Size
            attackLevel //Attack Damage
            );
    }

    public void KilledMob(MobStats mobStats)
    {
        experience += mobStats.Experience;
        OnStatChange?.Invoke();
        ActiveGame.instance.SaveGame();
    }
}
