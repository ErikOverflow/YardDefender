using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private const float DefaultAttackSpeed = 0.5f; //Number of attacks per second
    private const float DefaultBarkSize = 2f;

    int playerId = 0;
    [SerializeField] int gold = 0;
    [SerializeField] int level = 1;
    [SerializeField] int experience = 0;
    int nextLevelExperience = 0;
    [SerializeField] int attackLevel = 1;
    [SerializeField] BarkController barkController = null;
    [SerializeField] PlayerEquipment playerEquipment = null; //Only READ from the equipment

    public int PlayerId { get => playerId; }
    public int Gold { get => gold; }
    public int Level { get => level; }
    public int Experience { get => experience; }
    public int AttackLevel { get => attackLevel; }
    public int Damage { get => CalculateDamage(); }

    public IEnumerable<WeaponData> PlayerWeapons { get => playerEquipment.WeaponInventory;}

    public Action OnStatChange;

    private void Start()
    {
        ActiveGame.instance.SetPlayerStats(this);
        ActiveGame.instance.LoadGame();

        KillManager.instance.OnKill += EnemyKilled;
        playerEquipment.OnEquipmentChange += CalculateStats;

    }

    private void EnemyKilled(MobStats mobStats, PlayerStats playerStats)
    {
        experience += mobStats.Experience;
        gold += mobStats.Gold;
        CalculateStats();
        ActiveGame.instance.SaveGame();
        OnStatChange?.Invoke();
    }

    private int CalculateDamage()
    {
        return Mathf.FloorToInt((attackLevel + playerEquipment.FlatDamage) * level * playerEquipment.MultiplierDamage);
    }

    public void Initialize(PlayerData playerData, SaveData saveData, IEnumerable<WeaponData> weaponDatas)
    {
        playerId = playerData.Id;
        gold = saveData.Gold;
        level = playerData.Level;
        experience = playerData.Experience;
        nextLevelExperience = CalculateNextLevelExp();
        attackLevel = playerData.AttackLevel;
        playerEquipment.Initialize(weaponDatas);
        CalculateStats();
        OnStatChange?.Invoke();
    }

    public void CalculateStats()
    {
        while (experience >= nextLevelExperience)
        {
            level++;
            experience -= nextLevelExperience;
            nextLevelExperience = CalculateNextLevelExp();
        }
        barkController.Initialize(
            DefaultBarkSize, //Attack Size
            Damage//Attack Damage
            );
    }

    int CalculateNextLevelExp()
    {
        return 100;
        //return Mathf.FloorToInt(Mathf.Pow(10, Mathf.Pow(1.1f, level)));
    }

    public void OnDestroy()
    {
        KillManager.instance.OnKill -= EnemyKilled;
        playerEquipment.OnEquipmentChange -= CalculateStats;
    }
}
