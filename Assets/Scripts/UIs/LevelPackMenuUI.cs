using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelPackMenuUI : MonoBehaviour
{
    [SerializeField] private LevelPack[] levelPacks;
    [SerializeField] private LevelPackOptionUI levelPackOptionPrefab;
    [SerializeField] private RectTransform buttonsParent;

    [Header("Caches")]
    [SerializeField] private QuestionMenuUI questionMenu;


    private void Start()
    {
        GenerateOptionButtons();

        SubscribeEvents();
    }

    private void GenerateOptionButtons()
    {
        foreach(LevelPack lp in levelPacks)
        {
            var levelPackOptionButton = Instantiate(levelPackOptionPrefab);

            levelPackOptionButton.Setup(lp);

            // better approach
            levelPackOptionButton.transform.SetParent(buttonsParent, false);

            //levelPackOptionButton.transform.parent = buttonsParent;
            //levelPackOptionButton.transform.localScale = Vector3.one;
        }
    }


    private void OnDestroy()
    {
        UnsubscribeEvents();
    }

    private void SubscribeEvents()
    {
        LevelPackOptionUI.OnClickingLevelPackOptionButton += SetupQuestionMenu;
    }
    private void UnsubscribeEvents()
    {
        LevelPackOptionUI.OnClickingLevelPackOptionButton -= SetupQuestionMenu;
    }


    private void SetupQuestionMenu(LevelPack levelPack)
    {
        questionMenu.gameObject.SetActive(true);
        questionMenu.GenerateOptionButtons(levelPack);

        gameObject.SetActive(false);
    }
}
