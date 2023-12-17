using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class CoinUI : MonoBehaviour
{
    [SerializeField] private PlayerProgressData playerProgressData;
    [SerializeField] private TextMeshProUGUI coinText;

    private void Awake()
    {
        playerProgressData.Setup();
    }

    private void Start()
    {
        if (!playerProgressData.Load())
        {
            playerProgressData.Save();
        }

        UpdateCoinText();
    }

    private void UpdateCoinText()
    {
        coinText.text = playerProgressData.data.coins.ToString();
    }



}
