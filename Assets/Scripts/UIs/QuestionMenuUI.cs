using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionMenuUI : MonoBehaviour
{
    [SerializeField] private TransitoryData transitoryDataReference;
    [SerializeField] private LevelPack currentSelectedLevelPack;
    [SerializeField] private QuestionOptionUI questionOptionPrefab;
    [SerializeField] private RectTransform buttonsParent;

    private void Start()
    {
        SubscribeEvents();
    }

    public void GenerateOptionButtons(LevelPack levelPack)
    {
        RefreshContent();

        currentSelectedLevelPack = levelPack;

        for(int i=0; i<levelPack.totalQuestion; i++)
        {
            var questionOptionButton = Instantiate(questionOptionPrefab);

            questionOptionButton.Setup(levelPack.GetQuestionDataByIndex(i));

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
        transitoryDataReference.currentLevelPack = currentSelectedLevelPack;
        transitoryDataReference.currentQuestionIndex = index;


        var sceneLoader = FindObjectOfType<SceneLoader>();
        if (sceneLoader == null)
        {
            print("Error: SceneLoader not found");
            return;
        }

        sceneLoader.LoadGameScene();
    }
}
