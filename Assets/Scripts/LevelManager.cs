using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private TransitoryData transitoryDataRef;
    [SerializeField] private LevelPack levelPack;
    [SerializeField] private int questionIndex;

    [SerializeField] private QuestionUI questionUI;
    [SerializeField] private AnswerOptionUI[] answerOptionUis = new AnswerOptionUI[0];

    [SerializeField] private PlayerProgressData playerProgressData;
    [SerializeField] private int coinReward;

    //[Header("Caches")]
    //[SerializeField] private SceneLoader sceneLoader;

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

        FetchTransitoryData();
        NextQuestion();
    }

    private void FetchTransitoryData()
    {
        if(transitoryDataRef.currentLevelPack == null)
        {
            print("Error on Transitory Data");
            questionIndex = -1;
            return;
        }

        levelPack = transitoryDataRef.currentLevelPack;
        questionIndex = transitoryDataRef.currentQuestionIndex - 1;
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
        /*
         * saya prefer untuk mendapatkan reference SceneLoader via FindObjectOfType() 
         * karena reference sangat jarang digunakan di lifetime scene
         */
        var sceneLoader = FindObjectOfType<SceneLoader>();
        if (sceneLoader == null)
        {
            print("Error: SceneLoader not found");
            return;
        }

        sceneLoader.LoadChooseLevelMenuScene();
    }

    public void AddCoinReward()
    {
        print("hoy");
        playerProgressData.data.coins += coinReward;
    }

    public void ResetLevel()
    {
        questionIndex = -1;
        NextQuestion();
    }


    private void OnApplicationQuit()
    {
        transitoryDataRef.Reset();
    }



}
