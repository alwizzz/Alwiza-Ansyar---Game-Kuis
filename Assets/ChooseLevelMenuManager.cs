using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChooseLevelMenuManager : MonoBehaviour
{
    [SerializeField] private PlayerProgressData playerProgressData;
    [SerializeField] private LevelPack[] levelPacks;
    [SerializeField] private TextMeshProUGUI coinText;

    [Header("Caches")]
    [SerializeField] private LevelPackMenuUI levelPackMenu;

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

        levelPackMenu.GenerateOptionButtons(levelPacks, playerProgressData.data);
        UpdateCoinText();
    }

    public void UpdateCoinText()
    {
        coinText.text = playerProgressData.data.coins.ToString();
    }

}
