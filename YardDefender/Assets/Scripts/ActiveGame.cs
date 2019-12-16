using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveGame : MonoBehaviour
{
    public static ActiveGame instance;
    public SaveData gameData;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void LoadGame(SaveData _gameData)
    {
        gameData = _gameData;
    }
}
