using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveGame : MonoBehaviour
{
    public static ActiveGame instance;
    SaveData saveData;
    [SerializeField]
    PlayerStats playerStats = null;

    DataService dataService= DataService.instance;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void LoadGame(SaveData _saveData)
    {
        saveData = _saveData;
        PlayerData playerData;
        playerData = dataService.ReadPlayerData(saveData.Id);
        playerStats.Initialize(playerData);
    }

    public void SaveGame()
    {
        dataService.WriteSaveData(saveData);
        PlayerData playerData = new PlayerData
        {
            GameId = saveData.Id,
            Id = playerStats.PlayerId,
            Level = playerStats.Level,
            Experience = playerStats.Experience,
            DamageLevel = playerStats.DamageLevel,
            SpeedLevel = playerStats.SpeedLevel
        };
        dataService.WritePlayerData(playerData);
    }
}
