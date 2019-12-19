using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveGame : MonoBehaviour
{
    public static ActiveGame instance;
    public SaveData saveData;
    public PlayerData playerData;

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
        playerData = DataService.instance.GetPlayerData(saveData.Id);
    }
}
