using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ErikOverflow.YardDefender
{
    public class SelectGameController : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI saveName = null;
#pragma warning disable 414
        [SerializeField] TextMeshProUGUI gold = null;
        [SerializeField] Object gameScene = null;

        SaveData saveData = null;

        public void SetData(SaveData _saveData)
        {
            saveData = _saveData;
            saveName.text = saveData.Name;
            //gold.text = gameData.Gold.ToString();
        }

        public void ContinueGame()
        {
            PlayerPrefs.SetInt("GameId", saveData.Id);
            SceneManager.LoadSceneAsync(gameScene.name);
        }

        public void DeleteGame()
        {
            DataService.instance.DeleteRow<SaveData>(saveData);
            Destroy(this.gameObject);
        }
    }
}