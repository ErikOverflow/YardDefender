using SQLite4Unity3d;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


//We place all of our connections in a single data service 
public class DataService : MonoBehaviour
{
    public static DataService instance;
    private SQLiteConnection _connection;
    [SerializeField]
    string databaseName = "game.db";

    public void Awake()
    {
        if(instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        string databasePath = string.Format("{0}/{1}", Application.persistentDataPath, databaseName);
        if (!File.Exists(databasePath))
        {
            using (FileStream fs = File.Create(databasePath))
            {
                fs.Close();
            }
        }
        _connection = new SQLiteConnection(databasePath);
        CreateDB();
    }

    public void CreateDB()
    {
        //Create all relavant tables if they don't exist yet
        _connection.CreateTable<SaveData>();
        _connection.CreateTable<PlayerData>();
    }

    public IEnumerable<SaveData> GetGameDatas()
    {
        return _connection.Table<SaveData>();
    }

    public void SaveGameData(SaveData gameData)
    {
        _connection.Insert(gameData);
    }

    public void SavePlayerData(PlayerData playerData)
    {
        _connection.Insert(playerData);
    }

    public PlayerData GetPlayerData(int gameId)
    {
        PlayerData pd = _connection.Table<PlayerData>().Where(cd => cd.GameId == gameId).FirstOrDefault();
        if (pd == null)
        {
            pd = new PlayerData() { GameId = gameId };
            SavePlayerData(pd);
        }
        return pd;
    }

    public SaveData GetGameData()
    {
        return _connection.Table<SaveData>().FirstOrDefault();
    }

    public SaveData GetGameData(int id)
    {
        return _connection.Table<SaveData>().Where(gd => gd.Id == id).FirstOrDefault();
    }

    public void DeleteGameData(int id)
    {
        _connection.Delete<SaveData>(id);
    }

    private void OnDestroy()
    {
        _connection?.Close();
    }
}
