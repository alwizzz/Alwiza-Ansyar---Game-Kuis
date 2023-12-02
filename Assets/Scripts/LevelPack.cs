using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
    fileName = "LevelPack",
    menuName = "QuizGame/LevelPack"
)]
public class LevelPack : ScriptableObject
{
    [SerializeField] private QuestionData[] questions = new QuestionData[0];
    public int totalQuestion => questions.Length;


    public QuestionData GetQuestionDataByIndex(int index)
    {
        return questions[index];
    }
}
