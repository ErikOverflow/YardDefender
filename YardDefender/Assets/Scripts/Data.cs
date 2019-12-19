using SQLite4Unity3d;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveData
{
    [SerializeField]
    private int id;
    [SerializeField]
    private string name;
    [SerializeField]
    private int gold;
    [SerializeField]
    private bool newGamePlus;

    [AutoIncrement, PrimaryKey]
    public int Id
    {
        get
        {
            return id;
        }
        set
        {
            id = value;
        }
    }
    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            name = value;
        }
    }
    public int Gold
    {
        get
        {
            return gold;
        }
        set
        {
            gold = value;
        }
    }
    public bool NewGamePlus
    {
        get
        {
            return newGamePlus;
        }
        set
        {
            newGamePlus = value;
        }
    }
}

[Serializable]
public class PlayerData
{
    [SerializeField]
    int id;
    [SerializeField]
    int gameId;
    [SerializeField]
    int level = 1;
    [SerializeField]
    int experience = 0;
    [SerializeField]
    int damageLevel = 1;
    [SerializeField]
    int speedLevel = 1;

    [AutoIncrement, PrimaryKey]
    public int Id
    {
        get
        {
            return id;
        }
        set
        {
            id = value;
        }
    }
    public int GameId
    {
        get
        {
            return gameId;
        }
        set
        {
            gameId = value;
        }
    }
    public int Level
    {
        get
        {
            return level;
        }
        set
        {
            level = value;
        }
    }
    public int Experience
    {
        get
        {
            return experience;
        }
        set
        {
            experience = value;
        }
    }
    public int DamageLevel
    {
        get
        {
            return damageLevel;
        }
        set
        {
            damageLevel = value;
        }
    }
    public int SpeedLevel
    {
        get
        {
            return speedLevel;
        }
        set
        {
            speedLevel = value;
        }
    }
}