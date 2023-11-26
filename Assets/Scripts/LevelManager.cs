using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [System.Serializable]
    private struct QuestionData
    {
        public string questionString;
        public Sprite hintSprite;

        public string[] answerStringArray;
        public bool[] isCorrectArray;
    }

    [SerializeField] private QuestionData[] questions = new QuestionData[0];
    [SerializeField] private Question question;
    [SerializeField] private AnswerOption[] answerOptions = new AnswerOption[0];
    [SerializeField] private int questionIndex;


    private void Start()
    {
        questionIndex = -1;
        NextQuestion();
    }

    public void NextQuestion()
    {
        questionIndex++;
        if(questionIndex >= questions.Length) { questionIndex = 0; }

        QuestionData data = questions[questionIndex];
        question.SetQuestion($"Level {questionIndex+1}", data.questionString, data.hintSprite);

        for(int i=0; i<answerOptions.Length; i++)
        {
            AnswerOption option = answerOptions[i];
            option.SetAnswerOption(data.answerStringArray[i], data.isCorrectArray[i]);
        }

    }

}
