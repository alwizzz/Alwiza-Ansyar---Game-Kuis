using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
    fileName = "QuestionData", 
    menuName = "QuizGame/QuestionData"
)]
public class QuestionData : ScriptableObject
{
    [System.Serializable]
    public struct AnswerOption
    {
        public string answerString;
        public bool isCorrect;
    }

    public string questionString;
    public Sprite hintSprite;

    public AnswerOption[] answerOptions = new AnswerOption[0];
}
