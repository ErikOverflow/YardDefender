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
    private int level;
    [SerializeField]
    private int experience;
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