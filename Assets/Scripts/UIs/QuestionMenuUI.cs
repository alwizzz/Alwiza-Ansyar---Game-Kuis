using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionMenuUI : MonoBehaviour
{
    [SerializeField] private TransitoryData transitoryDataRef;
    [SerializeField] private LevelPack currentSelectedLevelPack;
    [SerializeField] private QuestionOptionUI questionOptionPrefab;
    [SerializeField] private RectTransform buttonsParent;

    private void Start()
    {
        SubscribeEvents();
    }

    public void GenerateOptionButtons(LevelPack levelPack, int levelProgress)
    {
        RefreshContent();

        currentSelectedLevelPack = levelPack;

        for(int i=0; i<levelPack.totalQuestion; i++)
        {
            var questionOptionButton = Instantiate(questionOptionPrefab);

            var questionData = levelPack.GetQuestionDataByIndex(i);
            var isLocked = (i < levelProgress ? false : true);
            questionOptionButton.Setup(questionData, isLocked);

            // better approach
            questionOptionButton.transform.SetParent(buttonsParent, false);

            //levelPackButton.transform.parent = buttonsParent;
            //levelPackButton.transform.localScale = Vector3.one;
        }
    }

    private void RefreshContent()
    {
        for(int i=0; i<buttonsParent.childCount; i++)
        {
            Destroy(buttonsParent.GetChild(i).gameObject);
        }
    }

    private void OnDestroy()
    {
        UnsubscribeEvents();
    }

    private void SubscribeEvents()
    {
        QuestionOptionUI.OnClick += LoadGame;
    }
    private void UnsubscribeEvents()
    {
        QuestionOptionUI.OnClick -= LoadGame;
    }

    private void LoadGame(int index)
    {
        transitoryDataRef.currentLevelPack = currentSelectedLevelPack;
        transitoryDataRef.currentQuestionIndex = index;


        var sceneLoader = FindObjectOfType<SceneLoader>();
        if (sceneLoader == null)
        {
            print("Error: SceneLoader not found");
            return;
        }

        sceneLoader.LoadGameScene();
    }
}
