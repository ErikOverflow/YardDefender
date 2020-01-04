using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ErikOverflow.YardDefender
{
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
            SaveData saveData = DataService.instance.CreateRow<SaveData>();
            saveData.Name = nameField.text;
            DataService.instance.UpdateRow<SaveData>(saveData);
            PlayerPrefs.SetInt("GameId", saveData.Id);

            //Load newGameData here
            SceneManager.LoadSceneAsync(gameScene.name);
        }
    }
}