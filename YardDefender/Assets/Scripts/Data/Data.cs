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
        int id;
        [AutoIncrement, PrimaryKey] public int Id { get => id; set => id = value; }
    }

    /// <summary>
    /// Contains a gameId that allows it to be automatically queried using gameId.
    /// </summary>
    [Serializable]
    public abstract class GameData : Data
    {
        [SerializeField] int gameId;

        public int GameId { get => gameId; set => gameId = value; }
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
    public abstract class ItemData : GameData
    {
        [SerializeField] string name;

        public string Name { get => name; set => name = value; }
    }

    [Serializable]
    public class WeaponData : ItemData
    {
        [SerializeField] int damage;
        [SerializeField] int multiplier;

        public int Damage { get => damage; set => damage = value; }
        public int Multiplier { get => multiplier; set => multiplier = value; }
    }
}