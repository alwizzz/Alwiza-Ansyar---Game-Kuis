using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionMenuUI : MonoBehaviour
{
    [SerializeField] private LevelPack currentSelectedLevelPack;
    [SerializeField] private QuestionOptionUI questionOptionPrefab;
    [SerializeField] private RectTransform buttonsParent;


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
}
