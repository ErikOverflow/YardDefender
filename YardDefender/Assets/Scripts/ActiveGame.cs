using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ActiveGame : MonoBehaviour
{
    public static ActiveGame instance;
    [SerializeField] int saveId = 0;
    [SerializeField] PlayerStats playerStats = null;

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

    public void SetPlayerStats(PlayerStats _playerStats)
    {
        playerStats = _playerStats;
    }

    public void SetSaveId(int id)
    {
        saveId = id;
    }

    public void LoadGame()
    {
        SaveData saveData = DataService.instance.ReadSaveData(saveId);
        if(saveData == null)
        {
            return;
        }
        //Get all playerdatas related to the save
        IEnumerable<PlayerData> playerDatas = DataService.instance.GetPlayerDatas(saveData);
        PlayerData playerData = playerDatas.FirstOrDefault();
        //Update playerstats with the first one in the playerdatas list
        playerStats?.Initialize(playerDatas.FirstOrDefault(), saveData);
    }

    public void SaveGame()
    {
        //Update SaveData
        SaveData saveData = DataService.instance.ReadSaveData(saveId);
        saveData.Gold = playerStats.Gold;
        DataService.instance.UpdateSaveData(saveData);

        IEnumerable<PlayerData> playerDatas = DataService.instance.GetPlayerDatas(saveData);
        PlayerData playerData = playerDatas.FirstOrDefault();
        playerData.Level = playerStats.Level;
        playerData.Experience = playerStats.Experience;
        playerData.AttackLevel = playerStats.AttackLevel;
        DataService.instance.UpdatePlayerData(playerData);
    }
}
