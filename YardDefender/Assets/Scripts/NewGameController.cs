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
        SaveData newGameData = new SaveData
        {
            Name = nameField.text,
            Level = 1,
            Experience = 0,
            Gold = 100,
            NewGamePlus = ngPlus.isOn
        };
        DataService.instance.SaveGameData(newGameData);
        //Load newGameData here
        SceneManager.LoadSceneAsync(gameScene.name);
    }
}
