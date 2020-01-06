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
        [SerializeField] TMP_InputField nameField = null;
#pragma warning disable 414
        [SerializeField] Toggle ngPlus = null;
        [SerializeField] Object gameScene = null;

        SaveInfo saveInfo = null;

        public SaveInfo SaveInfo { set => saveInfo = value; }

        public void CreateGame()
        {
            int saveId = saveInfo.NewGame(nameField.text);
            PlayerPrefs.SetInt("GameId", saveId);

            //Load next scene with current save ID
            SceneManager.LoadSceneAsync(gameScene.name);
        }
    }
}