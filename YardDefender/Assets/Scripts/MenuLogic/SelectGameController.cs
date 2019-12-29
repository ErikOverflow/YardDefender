using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectGameController : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI saveName = null;
    [SerializeField]
    TextMeshProUGUI gold = null;
    [SerializeField]
    Object gameScene = null;

    SaveData gameData = null;

    public void SetData(SaveData _gameData)
    {
        gameData = _gameData;
        saveName.text = gameData.Name;
        gold.text = gameData.Gold.ToString();
    }

    public void ContinueGame()
    {
        ActiveGame.instance.SetSaveId(gameData.Id);
        //Load Scene
        SceneManager.LoadSceneAsync(gameScene.name);
    }

    public void DeleteGame()
    {
        DataService.instance.RecursiveDeleteSaveData(gameData.Id);
        Destroy(this.gameObject);
    }
}
