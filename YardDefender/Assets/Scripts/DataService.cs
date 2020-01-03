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
    [SerializeField] string databaseName = "game.db";

    public void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
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
        _connection.CreateTable<SaveData>();
        _connection.CreateTable<PlayerData>();
        _connection.CreateTable<WeaponData>();
        _connection.CreateTable<LevelData>();
    }

    //Generic CRUD
    public int CreateRow<T>() where T : Data, new()
    {
        T newData = new T();
        _connection.Insert(newData);
        return newData.Id;
    }

    public T ReadData<T>(int id) where T : Data, new()
    {
        return _connection.Table<T>().Where(row => row.Id == id).FirstOrDefault();
    }

    public T ReadGameData<T>(int gameId) where T: GameData, new()
    {
        return _connection.Table<T>().Where(row => row.GameId == gameId).FirstOrDefault();
    }

    public void UpdateData<T>(T dataToUpdate)
    {
        _connection.Update(dataToUpdate);
    }

    public void DeleteData<T>(T dataToDelete)
    {
        _connection.Delete(dataToDelete);
    }

    //LevelData CRUD

    public int CreateLevelData()
    {
        LevelData newData = new LevelData();
        _connection.Insert(newData);
        return newData.Id;
    }

    // CRUD for SaveData

    /// <summary>
    /// Creates a new SaveData in the database.
    /// </summary>
    /// <returns>ID of the newly created SaveData</returns>
    public int CreateSaveData()
    {
        SaveData newSaveData = new SaveData();
        _connection.Insert(newSaveData);
        return newSaveData.Id;
    }

    public void CreateSaveData(SaveData saveData) //For debugging purposes only
    {
        _connection.Insert(saveData);
    }

    public IEnumerable<SaveData> ReadSaveDatas()
    {
        return _connection.Table<SaveData>();
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

    public IEnumerable<PlayerData> ReadPlayerDatas(SaveData saveData)
    {
        return _connection.Table<PlayerData>().Where(pd => pd.GameId == saveData.Id);
    }

    //Crud for PlayerData

    /// <summary>
    /// Creates a new PlayerData in the database.
    /// </summary>
    /// <returns>ID of the newly created PlayerData</returns>
    public int CreatePlayerData()
    {
        PlayerData newPlayerData = new PlayerData();
        _connection.Insert(newPlayerData);
        return newPlayerData.Id;
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

    //CRUD for WeaponData

    /// <summary>
    /// Creates a new WeaponData in the database.
    /// </summary>
    /// <returns>ID of the newly created WeaponData</returns>
    public int CreateWeaponData()
    {
        WeaponData newWeaponData = new WeaponData();
        _connection.Insert(newWeaponData);
        return newWeaponData.Id;
    }

    public WeaponData ReadWeaponData(int id)
    {
        return _connection.Table<WeaponData>().Where(wd => wd.Id == id).FirstOrDefault();
    }

    public IEnumerable<WeaponData> ReadWeaponDatas(int playerId)
    {
        return _connection.Table<WeaponData>().Where(wd => wd.PlayerId == playerId);
    }

    public void UpdateWeaponData(WeaponData weaponData)
    {
        _connection.Update(weaponData);
    }

    public void UpdateWeaponDatas(IEnumerable<WeaponData> weaponDatas)
    {
        _connection.UpdateAll(weaponDatas);
    }

    public void DeleteWeaponData(WeaponData weaponData)
    {
        _connection.Delete(weaponData);
    }

    public void DeleteWeaponDatas(IEnumerable<WeaponData> weaponDatas)
    {
        foreach (WeaponData weaponData in weaponDatas)
        {
            DeleteWeaponData(weaponData);
        }
    }

    /// <summary>
    /// Deletes the SaveData and any related PlayerData
    /// </summary>
    /// <param name="id">SaveData ID</param>
    public void RecursiveDeleteSaveData(int id)
    {
        SaveData saveData = ReadSaveData(id);
        _connection.Delete(saveData);
        IEnumerable<PlayerData> playerDatas = ReadPlayerDatas(saveData);
        foreach (PlayerData playerData in playerDatas)
        {
            DeletePlayerData(playerData);
        }
    }

    private void OnDestroy()
    {
        _connection?.Close();
    }
}
