using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveGame : MonoBehaviour
{
    public static ActiveGame instance;
    SaveData saveData;
    [SerializeField] PlayerStats playerStats = null;

    private void Awake()
    {
        if(instance != null)
        {
            instance.LoadGame();
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void LoadGame()
    {
        LoadGame(saveData);
    }

    public void LoadGame(SaveData _saveData)
    {
        saveData = _saveData;
        PlayerData playerData;
        playerData = DataService.instance.ReadPlayerData(saveData.Id);
        playerStats.Initialize(playerData);
    }

    public void SaveGame()
    {
        if(saveData == null)
        {
            saveData = new SaveData();
        }
        DataService.instance.WriteSaveData(saveData);
        PlayerData playerData = new PlayerData
        {
            GameId = saveData.Id,
            Id = playerStats.PlayerId,
            Level = playerStats.Level,
            Experience = playerStats.Experience,
            DamageLevel = playerStats.AttackLevel,
            SpeedLevel = playerStats.SpeedLevel
        };
        DataService.instance.WritePlayerData(playerData);
    }
}
