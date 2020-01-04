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
}