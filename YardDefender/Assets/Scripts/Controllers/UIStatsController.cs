using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace ErikOverflow.YardDefender
{
    public class UIStatsController : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI goldAmountText = null;
        [SerializeField] TextMeshProUGUI expAmountText = null;
        [SerializeField] TextMeshProUGUI levelAmountText = null;
        [SerializeField] TextMeshProUGUI attackAmountText = null;
        [SerializeField] PlayerInfo playerInfo = null;

        // Start is called before the first frame update
        void Awake()
        {
            EventManager.instance.OnPlayerInfoChanged += ReloadUI;
            EventManager.instance.OnPlayerEquipmentChanged += ReloadUI;
        }

        // Update is called once per frame
        void ReloadUI()
        {
            goldAmountText.text = playerInfo.PlayerData.Gold.ToString();
            expAmountText.text = playerInfo.PlayerData.Experience.ToString();
            levelAmountText.text = playerInfo.PlayerData.Level.ToString();
            attackAmountText.text = playerInfo.Attack.ToString();
        }
    }
}