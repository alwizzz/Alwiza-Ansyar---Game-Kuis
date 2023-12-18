using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelPackMenuUI : MonoBehaviour
{
    [SerializeField] private TransitoryData transitoryDataRef;
    //[SerializeField] private LevelPack[] levelPacks;
    [SerializeField] private LevelPackOptionUI levelPackOptionPrefab;
    [SerializeField] private RectTransform buttonsParent;

    [Header("Caches")]
    [SerializeField] private QuestionMenuUI questionMenu;
    [SerializeField] private ChooseLevelMenuManager chooseLevelMenuManager;


    private void Start()
    {
        //GenerateOptionButtons();

        SubscribeEvents();

        if (transitoryDataRef.onLosingFromGame )
        {
            if(transitoryDataRef.currentLevelPack == null)
            {
                print("attempted to do onLosingFromGame mechanic but the currentLevelPack is null, canceled");
            } else
            {
                print("attempted to do onLosingFromGame mechanic, succeed");

                // force choosing a level pack via script
                transitoryDataRef.onLosingFromGame = false;
                OpenQuestionMenu(transitoryDataRef.currentLevelPack);
            }
        } else
        {
            questionMenu.gameObject.SetActive(false);
        }

    }

    public void GenerateOptionButtons(LevelPack[] levelPacks, PlayerProgressData.ProgressData data)
    {
        foreach(LevelPack lp in levelPacks)
        {
            var levelPackOptionButton = Instantiate(levelPackOptionPrefab);

            levelPackOptionButton.Setup(lp);

            // better approach
            levelPackOptionButton.transform.SetParent(buttonsParent, false);
            
            if(data.levelProgresses.ContainsKey(lp.name))
            {
                levelPackOptionButton.Unlock();
            } else
            {
                levelPackOptionButton.Lock();
            }
        }
    }


    private void OnDestroy()
    {
        UnsubscribeEvents();
    }

    private void SubscribeEvents()
    {
        LevelPackOptionUI.OnClick += OpenLevelPack;
    }
    private void UnsubscribeEvents()
    {
        LevelPackOptionUI.OnClick -= OpenLevelPack;
    }

    private void OpenLevelPack(LevelPack levelPack, bool isLocked)
    {
        if(isLocked) { return; }

        OpenQuestionMenu(levelPack);
    }


    private void OpenQuestionMenu(LevelPack levelPack)
    {
        int levelProgress = chooseLevelMenuManager.GetLevelProgress(levelPack.name);
        if(levelProgress == -1) // error code
        {
            print("ERROR");
            return;
        }

        questionMenu.gameObject.SetActive(true);
        questionMenu.GenerateOptionButtons(levelPack, levelProgress);

        gameObject.SetActive(false);
    }


    private void OnApplicationQuit()
    {
        transitoryDataRef.Reset();
    }
}
