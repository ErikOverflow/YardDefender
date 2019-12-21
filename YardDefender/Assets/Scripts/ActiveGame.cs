using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveGame : MonoBehaviour
{
    public static ActiveGame instance;
    public SaveData saveData;
    public PlayerData playerData;

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
        playerData = dataService.ReadPlayerData(saveData.Id);
    }

    public void SaveGame()
    {
        dataService.WriteSaveData(saveData);
        dataService.WritePlayerData(playerData);
    }
}
