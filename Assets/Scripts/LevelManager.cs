using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private LevelPack levelPack;
    [SerializeField] private int questionIndex;

    [SerializeField] private QuestionUI questionUI;
    [SerializeField] private AnswerOptionUI[] answerOptionUis = new AnswerOptionUI[0];

    [SerializeField] private PlayerProgressData playerProgressData;

    [Header("Caches")]
    [SerializeField] private SceneLoader sceneLoader;

    private void Awake()
    {
        playerProgressData.Setup();    
    }

    private void Start()
    {
        if(!playerProgressData.Load())
        {
            playerProgressData.Save();
        }

        questionIndex = -1;
        NextQuestion();
    }

    public void NextQuestion()
    {
        questionIndex++;
        if(questionIndex >= levelPack.totalQuestion) 
        {
            ReturnToChooseLevelMenu();
            return;
        }

        QuestionData data = levelPack.GetQuestionDataByIndex(questionIndex);
        questionUI.SetQuestion($"Level {questionIndex+1}", data.questionString, data.hintSprite);

        for(int i=0; i<answerOptionUis.Length; i++)
        {
            AnswerOptionUI optionUI = answerOptionUis[i];
            QuestionData.AnswerOption option = data.answerOptions[i];
            optionUI.SetAnswerOption(option.answerString, option.isCorrect);
        }

    }

    public void SaveProgress()
    {
        playerProgressData.Save();
    }
    public void LoadProgress()
    {
        playerProgressData.Load();
    }

    private void ReturnToChooseLevelMenu()
    {
        sceneLoader.LoadChooseLevelMenuScene();
    }

}
