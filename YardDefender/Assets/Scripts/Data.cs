using SQLite4Unity3d;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class SaveData
{
    [SerializeField] private int id;
    [SerializeField] private string name = "UnNamed";
    [SerializeField] private int gold = 0;
    [SerializeField] private bool newGamePlus = false;

    [AutoIncrement, PrimaryKey] public int Id { get => id; set => id = value; }
    public string Name { get => name; set => name = value; }
    public int Gold { get => gold; set => gold = value; }
    public bool NewGamePlus { get => newGamePlus; set => newGamePlus = value; }
}

[Serializable]
public class PlayerData
{
    [SerializeField] int id;
    [SerializeField] int gameId;
    [SerializeField] int level = 1;
    [SerializeField] int experience = 0;
    [SerializeField] int attackLevel = 5;

    [AutoIncrement, PrimaryKey] public int Id { get => id; set => id = value; }
    public int GameId { get => gameId; set => gameId = value; }
    public int Level { get => level; set => level = value; }
    public int Experience { get => experience; set => experience = value; }
    public int AttackLevel { get => attackLevel; set => attackLevel = value; }
}

//[Serializable]
//public class WeaponData
//{
//    [SerializeField] int id;
//    [SerializeField] string name;
//    [SerializeField] int playerId;
//    [SerializeField] int flatDamage = 0;
//    [SerializeField] float damageMultiplier = 1f;
//    [SerializeField] bool equipped = false;

//    [AutoIncrement, PrimaryKey] public int Id { get => id; set => id = value; }
//    public string Name { get => name; set => name = value; }
//    public int PlayerId { get => playerId; set => playerId = value; }
//    public int FlatDamage { get => flatDamage; set => flatDamage = value; }
//    public float DamageMultiplier { get => damageMultiplier; set => damageMultiplier = value; }
//    public Sprite Sprite { get => WeaponTableManager.instance.GetWeapon(name).sprite; }
//    public int RerollCost { get => WeaponTableManager.instance.GetWeapon(name).rerollCost; }
//    public bool Equipped { get => equipped; set => equipped = value; }

//    public void Reroll()
//    {
//        Weapon weapon = //WeaponTableManager.instance.GetWeapon(name);
//        flatDamage = Random.Range(weapon.flatDamageMin, weapon.flatDamageMax + 1);
//        damageMultiplier = Random.Range(weapon.multiplierDamageMin, weapon.multiplierDamageMax);
//    }
//}

[Serializable]
public class LevelData : GameData
{
    [SerializeField] private int id;
    [SerializeField] int gameId;
    [SerializeField] private int level = 1;

    [AutoIncrement, PrimaryKey] public override int Id { get => id; set => id = value; }
    public int Level { get => level; set => level = value; }
    public override int GameId { get => gameId; set => gameId = value; }
}

[Serializable]
public abstract class Data
{
    [AutoIncrement, PrimaryKey] public virtual int Id { get; set; }
}

[Serializable]
public abstract class GameData : Data
{

    public abstract int GameId { get; set; }
}