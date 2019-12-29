using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Generates new game slot buttons
public class NewGameController : MonoBehaviour
{
    [SerializeField]
    TMP_InputField nameField = null;
    [SerializeField]
    Toggle ngPlus = null;
    [SerializeField]
    Object gameScene = null;

    void Start()
    {
        
        //if game has been beaten at least once, enable hardcore toggle
    }
    
    public void CreateGame()
    {
        //Create new SaveData
        int saveId = DataService.instance.CreateSaveData();
        SaveData newSaveData = DataService.instance.ReadSaveData(saveId);
        newSaveData.Name = nameField.text;
        newSaveData.Gold = 100;
        newSaveData.NewGamePlus = ngPlus.isOn;
        DataService.instance.UpdateSaveData(newSaveData);

        //Create new PlayerData
        int playerId = DataService.instance.CreatePlayerData();
        PlayerData newPlayerData = DataService.instance.ReadPlayerData(playerId);
        newPlayerData.GameId = newSaveData.Id;
        DataService.instance.UpdatePlayerData(newPlayerData);

        ActiveGame.instance.SetSaveId(newSaveData.Id);
        //Load newGameData here
        SceneManager.LoadSceneAsync(gameScene.name);
    }
}
