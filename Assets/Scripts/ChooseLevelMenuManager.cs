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

    private void UpdateCoinText()
    {
        coinText.text = playerProgressData.data.coins.ToString();
    }

    public int GetLevelProgress(string levelPackName)
    {
        int result;

        if(playerProgressData.data.levelProgresses.ContainsKey(levelPackName))
        {
            result = playerProgressData.data.levelProgresses[levelPackName];
        } else
        {
            result = -1; // error code
        }

        return result;
    }

    public void PurchaseLevelPack(LevelPack levelPack, LevelPackOptionUI levelPackOption)
    {
        playerProgressData.data.coins -= levelPack.GetPrice();
        playerProgressData.data.levelProgresses.Add(levelPack.name, 1);

        levelPackOption.Unlock();

        playerProgressData.Save();
        UpdateCoinText();
    }

}
