using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfo : MonoBehaviour
{
    [SerializeField] SaveData saveData;

    public SaveData SaveData { get => saveData; }
}
