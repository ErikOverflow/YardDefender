using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Generates the continuable games from the local SQLite database
public class LoadGameController : MonoBehaviour
{
    [SerializeField]
    GameObject saveSlotPrefab = null;
    [SerializeField]
    GameObject newGameSlotPrefab = null;
    [SerializeField]
    Transform saveSlotLayoutGroup = null;

    public void OnEnable()
    {
        foreach(Transform t in saveSlotLayoutGroup)
        {
            Destroy(t.gameObject);
        }
        IEnumerable<SaveData> gameDatas = DataService.instance.ReadSaveDatas();
        foreach(SaveData gameData in gameDatas)
        {
            GameObject gObj = Instantiate(saveSlotPrefab, saveSlotLayoutGroup);
            SelectGameController selectGameController = gObj.GetComponent<SelectGameController>();
            selectGameController.SetData(gameData);
        }
        Instantiate(newGameSlotPrefab, saveSlotLayoutGroup);
    }
}
