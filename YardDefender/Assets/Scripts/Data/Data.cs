using System;
using System.Collections;
using System.Collections.Generic;
using SQLite4Unity3d;
using UnityEngine;

namespace ErikOverflow.YardDefender
{
    /// <summary>
    /// This class contains a generic Id that allows it to be queried using id.
    /// </summary>
    [Serializable]
    public abstract class Data
    {
        [SerializeField] int id;
        [AutoIncrement, PrimaryKey] public int Id { get => id; set => id = value; }
    }

    /// <summary>
    /// Contains a gameId that allows it to be automatically queried using gameId.
    /// </summary>
    [Serializable]
    public abstract class GameData : Data
    {
        [SerializeField] int saveId;

        public int SaveId { get => saveId; set => saveId = value; }
    }

    /// <summary>
    /// Basic data about the current Game's name and game Id information.
    /// </summary>
    [Serializable]
    public class SaveData : Data
    {
        [SerializeField] string name;

        public string Name { get => name; set => name = value; }
    }

    [Serializable]
    public class PlayerData : GameData
    {
        [SerializeField] int level = 1;
        [SerializeField] int experience = 0;
        [SerializeField] int gold = 100;

        public int Level { get => level; set => level = value; }
        public int Experience { get => experience; set => experience = value; }
        public int Gold { get => gold; set => gold = value; }
    }

    [Serializable]
    public class EquipmentData : GameData
    {
        [SerializeField] int equippedWeapon;

        public int EquippedWeapon { get => equippedWeapon; set => equippedWeapon = value; }
    }

    [Serializable]
    public class ItemData : GameData
    {
        [SerializeField] string name;
        [SerializeField] int guid;

        public string Name { get => name; set => name = value; }
        public int Guid { get => guid; set => guid = value; }
    }

    [Serializable]
    public class WeaponData : ItemData
    {
        [SerializeField] int damage;
        [SerializeField] float multiplier;

        public int Damage { get => damage; set => damage = value; }
        public float Multiplier { get => multiplier; set => multiplier = value; }
    }

    // Currently not stored to DB
    [Serializable]
    public class HealthData
    {
        [SerializeField] int maxHealth;
        [SerializeField] int currentHealth;

        public int MaxHealth { get => maxHealth; set => maxHealth = value; }
        public int CurrentHealth { get => currentHealth; set => currentHealth = value; }
    }
}
