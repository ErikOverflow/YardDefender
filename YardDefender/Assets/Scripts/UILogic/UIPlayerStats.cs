﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIPlayerStats : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats = null;
    [SerializeField] TextMeshProUGUI goldText = null;
    [SerializeField] TextMeshProUGUI levelText = null;
    [SerializeField] TextMeshProUGUI experienceText = null;
    [SerializeField] TextMeshProUGUI attackText = null;

    void Start()
    {
        playerStats.OnStatChange += UpdateUI;
        UpdateUI();
    }

    void UpdateUI()
    {
        goldText.text = playerStats.Gold.ToString();
        levelText.text = playerStats.Level.ToString();
        experienceText.text = playerStats.Experience.ToString();
        attackText.text = playerStats.AttackLevel.ToString();
    }

    private void OnDestroy()
    {
        playerStats.OnStatChange -= UpdateUI;
    }
}
