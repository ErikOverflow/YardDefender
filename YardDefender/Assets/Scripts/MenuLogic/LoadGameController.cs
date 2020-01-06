using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Generates the continuable games from the local SQLite database
namespace ErikOverflow.YardDefender
{
    public class LoadGameController : MonoBehaviour
    {
        [SerializeField] GameObject saveSlotPrefab = null;
        [SerializeField] GameObject newGameSlotPrefab = null;
        [SerializeField] Transform saveSlotLayoutGroup = null;
        [SerializeField] SaveInfo saveInfo = null;

        void Start()
        {
            saveInfo.OnInfoChanged += InitializeSaveSlots;
            InitializeSaveSlots();
        }

        void InitializeSaveSlots()
        {
            //Deactive any currently visible save slots
            foreach(Transform t in saveSlotLayoutGroup)
            {
                t.gameObject.SetActive(false);
            }

            foreach(SaveData saveData in saveInfo.SaveDatas)
            {
                GameObject saveSlot = ObjectPooler.instance.GetPooledObject(saveSlotPrefab);
                saveSlot.transform.SetParent(saveSlotLayoutGroup);
                saveSlot.transform.localScale = Vector3.one;
                SelectGameController selectGameController = saveSlot.GetComponent<SelectGameController>();
                selectGameController.SetData(saveData);
            }
            GameObject newSlot = ObjectPooler.instance.GetPooledObject(newGameSlotPrefab);
            NewGameController newGameController = newSlot.GetComponent<NewGameController>();
            newGameController.SaveInfo = saveInfo;
            newSlot.transform.SetParent(saveSlotLayoutGroup);
            newSlot.transform.localScale = Vector3.one;
        }
    }
}
