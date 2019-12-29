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
            DontDestroyOnLoad(this.gameObject);
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
        Debug.Log(Application.persistentDataPath);
        _connection.CreateTable<SaveData>();
        _connection.CreateTable<PlayerData>();
    }

    public IEnumerable<SaveData> ReadSaveDatas()
    {
        return _connection.Table<SaveData>();
    }

    // CRUD for SaveData

    /// <summary>
    /// Creates a new SaveData in the database.
    /// </summary>
    /// <returns>ID of the newly created SaveData</returns>
    public int CreateSaveData()
    {
        return _connection.Insert(new SaveData());
    }

    public SaveData ReadSaveData(int id)
    {
        return _connection.Table<SaveData>().Where(sd => sd.Id == id).FirstOrDefault();
    }

    public void UpdateSaveData(SaveData saveData)
    {
        _connection.Update(saveData);
    }

    public void DeleteSaveData(SaveData saveData)
    {
        _connection.Delete(saveData);
    }

    public IEnumerable<PlayerData> GetPlayerDatas(SaveData saveData)
    {
        return _connection.Table<PlayerData>().Where(pd => pd.GameId == saveData.Id);
    }

    //Crud for PlayerData
    public int CreatePlayerData()
    {
        return _connection.Insert(new PlayerData());
    }

    public PlayerData ReadPlayerData(int id)
    {
        return _connection.Table<PlayerData>().Where(pd => pd.Id == id).FirstOrDefault();
    }

    public void UpdatePlayerData(PlayerData playerData)
    {
        _connection.Update(playerData);
    }
    public void DeletePlayerData(PlayerData playerData)
    {
        _connection.Delete(playerData);
    }



    /// <summary>
    /// Deletes the SaveData and any related PlayerData
    /// </summary>
    /// <param name="id">SaveData ID</param>
    public void RecursiveDeleteSaveData(int id)
    {
        SaveData saveData = ReadSaveData(id);
        _connection.Delete(saveData);
        IEnumerable<PlayerData> playerDatas = GetPlayerDatas(saveData);
        foreach(PlayerData playerData in playerDatas)
        {
            DeletePlayerData(playerData);
        }
    }

    private void OnDestroy()
    {
        _connection?.Close();
    }
}
